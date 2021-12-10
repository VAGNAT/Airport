using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.Controllers
{
    public class TerminalController : Controller
    {
        public IActionResult Serv()
        {
            return View();
        }
        public IActionResult Customer()
        {
            return View();
        }
    }
}
