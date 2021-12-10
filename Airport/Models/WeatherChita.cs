using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.Models
{
    public class WeatherChita
    {
        public List<Weather> Weather { get; set; }
        public MainWeather Main { get; set; }
        public Wind Wind { get; set; }
        public string Name { get; set; }
    }

    public class Wind
    {
        public double Speed { get; set; }
        public double Deg { get; set; }
    }

    public class Weather
    {
        public string Description { get; set; }
        public string Icon { get; set; }
    }
    public class MainWeather
    {
        public double Temp { get; set; }
        public double Feels_like { get; set; }
        public double Pressure { get; set; }
        public double Humidity { get; set; }
    }

}
