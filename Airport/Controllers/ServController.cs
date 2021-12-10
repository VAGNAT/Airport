using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.Controllers
{
    public class ServController : Controller
    {
        public IActionResult Cafe()
        {
            return View();
        }
        public IActionResult Vip()
        {
            return View();
        }
    }
}
