using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XtramileSolutions.API.Provider;

namespace XtramileSolutions.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WeatherController : Controller
    { 
        private IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            this._weatherService = weatherService;
        }

        [HttpGet]
        [Route("GetWeatherByCity")]
        public IActionResult GetWeatherByCity(long cityId)
        {
            try
            {
                var data = _weatherService.GetWeatherByCity(cityId);
                return Ok(data);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
