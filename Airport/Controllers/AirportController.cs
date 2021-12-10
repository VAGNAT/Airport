using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.Controllers
{
    public class AirportController : Controller
    {
        public IActionResult Information()
        {
            return View();
        }
        public IActionResult History()
        {
            return View();
        }
    }
}
