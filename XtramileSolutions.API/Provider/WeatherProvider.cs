using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XtramileSolutions.API.Models;
using XtramileSolutions.API.ViewModels;

namespace XtramileSolutions.API.Provider
{
    public interface IWeatherService
    {
        WeatherViewModel GetWeatherByCity(long cityId);

    }

    public class WeatherProvider : IWeatherService
    {
        public WeatherProvider()
        {
        }

        public WeatherViewModel GetWeatherByCity(long cityId)
        {

            var json = System.IO.File.ReadAllText("MockData/weather.json");
            var listWeather = JsonConvert.DeserializeObject<List<Weather>>(json);

            var weather = listWeather.Where(x => x.City.Id == cityId).FirstOrDefault();

            var celcius = (weather.Main.Temp - 273);
            var fahrenheit = (celcius  *18 / 10 + 32);

            WeatherViewModel weatherViewModel = new WeatherViewModel()
            {
                Location = weather.City.Name + ", Coordinates : longlitude = " + weather.City.Coord.Lon.ToString() + "; latitude = " + weather.City.Coord.Lat.ToString(),
                Time = DateTime.UnixEpoch.AddSeconds(weather.Time).ToString("dd-MMMM-yyyy hh:mm:ss"),
                Wind = "Speed : " + weather.Wind.Speed.ToString() + ", Degrees : " + weather.Wind.Deg.ToString() + ", Variable Begin : " + weather.Wind.VarBeg.ToString() + ", Variable End : " + weather.Wind.VarEnd.ToString(),
                Visibility = weather.Clouds.All,
                SkyCondition = weather.WeatherElement[0].Main.ToString(),
                TemperatureInCelcius = celcius,
                TemperatureInFahrenheith = fahrenheit,
                DewPoint = weather.Main.Humidity.ToString(),
                RelativeHumidity = weather.Main.Humidity.ToString(),
                Pressure = weather.Main.Pressure.ToString()
            };


            return weatherViewModel;
        }
    }
}
