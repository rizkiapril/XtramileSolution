using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XtramileSolutions.API.Models;

namespace XtramileSolutions.API.Provider
{
    public interface ICityService
    {
        List<City> GetCityByCountry(string country);

    }
    public class CityProvider : ICityService
    {
        public CityProvider()
        {
        }

        public List<City> GetCityByCountry(string country)
        {

            var json = System.IO.File.ReadAllText("MockData/weather.json");
            var listWeather = JsonConvert.DeserializeObject<List<Weather>>(json);

            var listCity = listWeather.Where(x => x.City.Country == country).Select(x => x.City).ToList();

            return listCity;
        }
    }
}
