using Airport.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public PlaneContext Context { get; }
        public IMemoryCache MemoryCache { get; }

        public HomeController(ILogger<HomeController> logger, PlaneContext context, IMemoryCache memoryCache)
        {
            _logger = logger;
            Context = context;
            MemoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            ViewBag.Planes = new DBReader(MemoryCache).GetPlanes(Context).GroupBy(p => p.Day).OrderBy(d => d.Key);
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Sub(Sub sub)
        {
            return View(sub);
        }
    }
}
