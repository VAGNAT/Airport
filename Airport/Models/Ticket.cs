using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.Models
{
    public class Ticket
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string DateStart { get; set; }
        [Required]
        public string Company { get; set; }
        public string Label { get; set; }
        public DateTime DepurtureTime { get; set; }
        public char Terminal { get; set; }
        public double TravelTime { get; set; }
        public double Price { get; set; }
        public string PlaneName { get; set; }

    }
}
