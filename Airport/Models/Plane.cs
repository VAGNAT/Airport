using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.Models
{
    public class Plane
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public AirCompany AirCompany { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime Day { get; set; }
        public Destination Destination { get; set; }
        public Terminal Terminal { get; set; }
        public double TravelTime { get; set; }
        public double Price { get; set; }
    }
}