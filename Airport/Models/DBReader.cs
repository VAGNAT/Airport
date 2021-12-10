using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Airport.Models
{
    public class DBReader
    {
        private IMemoryCache MemoryCache { get; }

        public DBReader(IMemoryCache memoryCache)
        {
            MemoryCache = memoryCache;
        }
        public List<Plane> GetPlanes(PlaneContext context)
        {
            if (!MemoryCache.TryGetValue("Plane_list", out object planes))
            {
                planes = (from plane in context.Planes
                         join air in context.AirCompanies on plane.AirCompany.Id equals air.Id
                         join term in context.Terminals on plane.Terminal.Id equals term.Id
                         join dest in context.Destinations on plane.Destination.Id equals dest.Id
                         where plane.DepartureTime > DateTime.Now.AddHours(-2)
                         where plane.DepartureTime < DateTime.Now.AddDays(7)
                         orderby plane.DepartureTime
                         select new Plane { Name = plane.Name, AirCompany = air, DepartureTime = plane.DepartureTime, Destination = dest, Terminal = term, TravelTime = plane.TravelTime, Price = plane.Price, Day = plane.Day }).ToList();

                MemoryCache.Set("Plane_list", planes, TimeSpan.FromSeconds(20 * 60));

            }
            return planes as List<Plane>;
            
        }

        public static List<Directions> GetDirections(PlaneContext context)
        {
            return (from plane in context.Planes
                        join air in context.AirCompanies on plane.AirCompany.Id equals air.Id
                        join dest in context.Destinations on plane.Destination.Id equals dest.Id
                        where plane.DepartureTime < DateTime.Now.AddDays(7)
                        where plane.DepartureTime > DateTime.Now
                        select new Directions { City = dest.City, AirCompany = air.Label, AirName = air.Name, Price = plane.Price, Day = plane.Day, Picture = dest.Picture}).ToList();
        }
        public static List<Directions> GetDirections(PlaneContext context,string city, DateTime dateStart, DateTime dateExpiration)
        {
            return (from plane in context.Planes
                    join air in context.AirCompanies on plane.AirCompany.Id equals air.Id
                    join dest in context.Destinations on plane.Destination.Id equals dest.Id
                    where plane.DepartureTime < dateExpiration
                    where plane.DepartureTime > dateStart
                    where dest.City == city
                    select new Directions { City = dest.City, AirCompany = air.Label, AirName = air.Name, Price = plane.Price, Day = plane.Day, Picture = dest.Picture }).ToList();
        }
        public static string GetDayOfWeek(DayOfWeek day)
        {
            return day switch
            {
                DayOfWeek.Sunday => "ВС",
                DayOfWeek.Monday => "ПН",
                DayOfWeek.Tuesday => "ВТ",
                DayOfWeek.Wednesday => "СР",
                DayOfWeek.Thursday => "ЧТ",
                DayOfWeek.Friday => "ПТ",
                DayOfWeek.Saturday => "СБ",
                _ => "ВС",
            };
        }
        public static List<String> GetCity(PlaneContext context)
        {

            return (from city in context.Destinations orderby city.City select city.City).ToList();
        }
        public static List<String> GetCompany(PlaneContext context, string direction, DateTime dateStart)
        {

            return (from plane in context.Planes 
                    join d in context.Destinations on plane.Destination.Id equals d.Id
                    join a in context.AirCompanies on plane.AirCompany.Id equals a.Id
                    where d.City==direction
                    where plane.Day == dateStart
                    select plane.AirCompany.Name).Distinct().ToList();
        }
        public static Ticket SupplementTicket(PlaneContext context, Ticket ticket)
        {
            var query = (from plane in context.Planes
                        where plane.AirCompany.Name == ticket.Company
                        where plane.Day == DateTime.Parse(ticket.DateStart)
                        where plane.Destination.City == ticket.City
                        select new { Label =  plane.AirCompany.Label, DepurtureTime = plane.DepartureTime, 
                            Terminal = plane.Terminal.Name, TravelTime = plane.TravelTime, Price = plane.Price, 
                            PlaneName = plane.Name, Abbr = plane.AirCompany.Abbr}).FirstOrDefault();
            ticket.Label = query.Label;
            ticket.DepurtureTime = query.DepurtureTime;
            ticket.Terminal = query.Terminal;
            ticket.TravelTime = query.TravelTime;
            ticket.Price = query.Price;
            ticket.PlaneName = query.Abbr + " " + query.PlaneName.ToString();
            return ticket;            
        }
    }
}
