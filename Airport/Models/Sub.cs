using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Airport.Models
{
    public class Sub
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
    
}
