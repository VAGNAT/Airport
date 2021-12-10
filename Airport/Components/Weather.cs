using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airport.Models;
using Microsoft.AspNetCore.Mvc;

namespace Airport.Components
{
    public class Weather : ViewComponent
    {
        private readonly WeatherService service;

        public Weather(WeatherService service)
        {
            this.service = service;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            WeatherChita weather = await service.GetWeatherAsync();
            ViewBag.DirectionWind = service.GetDirection(weather);
            return View(weather);
        }
    }
}
