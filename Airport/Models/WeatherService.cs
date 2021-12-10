using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Airport.Models
{
    public class WeatherService
    {
        private string url = "https://api.openweathermap.org/data/2.5/weather?q=Chita,Russia&units=metric&appid=3ccf922afb6e2820369dbb9d84e15725&lang=ru";

        public async Task<WeatherChita> GetWeatherAsync()
        {
            HttpClient http = new HttpClient();
            HttpResponseMessage response = await http.GetAsync(url);
            string content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<WeatherChita>(content);
        }
        public string GetDirection(WeatherChita weatherChita)
        {
            return weatherChita.Wind.Deg switch
            {
                < 10 => "C",
                < 80 => "CB",
                < 100 => "B",
                < 170 => "ЮВ",
                < 190 => "Ю",
                < 260 => "ЮЗ",
                < 280 => "З",
                < 350 => "СЗ",
                _ => "С",
            };
        }
    }
}
