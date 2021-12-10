using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.Controllers
{
    public class PassengerController : Controller
    {
        public IActionResult Regulation()
        {
            return View();
        }
        public IActionResult Inspection()
        {
            return View();
        }
        public IActionResult Bag()
        {
            return View();
        }
    }
}
