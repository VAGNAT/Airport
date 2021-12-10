using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airport.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;

namespace Airport.Controllers
{
    public class TicketController : Controller
    {
        private PlaneContext Context { get; }
        private IMemoryCache MemoryCache { get; }
        public TicketController(PlaneContext context, IMemoryCache memoryCache)
        {
            Context = context;
            MemoryCache = memoryCache;
        }

        public IActionResult City()
        {
            ViewBag.Directions = DBReader.GetDirections(Context);
            return View();
        }

        public IActionResult Day(Selection selection)
        {
            ViewBag.SelectItems = new SelectList(DBReader.GetCity(Context), selection.City);
            DateTime dateStart = DateTime.Today;
            //ViewBag.DateStart = dateStart;
            //ViewBag.City = city;
            DateTime dateExpiration = DateTime.Today.AddDays(7).AddSeconds(-1);
            //ViewBag.DateExpiration = dateExpiration;
            ViewBag.Directions = DBReader.GetDirections(Context, selection.City, dateStart, dateExpiration);
            selection.DateStart = dateStart;
            selection.DateExpiration = dateExpiration;
            return View(selection);
        }
        [HttpPost]
        public IActionResult DayChange(Selection selection)
        {
            ViewBag.SelectItems = new SelectList(DBReader.GetCity(Context), selection.City);
            DateTime dateStart = selection.DateStart;
            ViewBag.DateStart = dateStart;
            DateTime dateExpiration = selection.DateExpiration.AddDays(1).AddSeconds(-1);
            ViewBag.DateExpiration = dateExpiration;
            ViewBag.City = selection.City;
            ViewBag.Directions = DBReader.GetDirections(Context, selection.City, dateStart, dateExpiration);
            return View("Day",selection);
        }
        public IActionResult Ticket(string city, string dateStart)//убрал модель из-за валидации
        {
            DateTime date = DateTime.Parse(dateStart);
            List<string> companies = DBReader.GetCompany(Context, city, date);
            ViewBag.SelectItems = new SelectList(companies, companies.FirstOrDefault());
            ViewBag.City = city;
            ViewBag.DateStart = date;
            return View();
        }
        [HttpPost]
        public IActionResult Ticket(Ticket ticket)
        {
            ticket = DBReader.SupplementTicket(Context, ticket);
            //ViewBag.City = ticket.City;
            return View("Succses",ticket);
        }
    }
}
