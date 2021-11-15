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
    public class CityController : Controller
    {
        private ICityService _cityService;

        public CityController(ICityService cityService)
        {
            this._cityService = cityService;
        }

        [HttpGet]
        [Route("GetCity")]
        public IActionResult GetCity(string country)
        {
            try
            {
                var data = _cityService.GetCityByCountry(country);
                return Ok(data);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
