using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.Models
{
    public class Selection
    {
        [Required]
        public string City { get; set; }
        [Required]
        public DateTime DateStart { get; set; }
        [Required]
        public DateTime DateExpiration { get; set; }
    }
}
