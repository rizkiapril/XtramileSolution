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
    public class CountryController : Controller
    {

        private ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            this._countryService = countryService;
        }

        [HttpGet]
        [Route("GetCountryList")]
        public IActionResult GetCountryList()
        {
            try
            {
                var data = _countryService.GetAll();      
                return Ok(data);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
