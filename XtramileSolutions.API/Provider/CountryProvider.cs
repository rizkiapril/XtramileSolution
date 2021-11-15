using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XtramileSolutions.API.Models;

namespace XtramileSolutions.API.Provider
{
    public interface ICountryService
    {
        List<Country> GetAll();
        
    }
    public class CountryProvider : ICountryService
    {
        public CountryProvider()
        {
        }

        public List<Country> GetAll()
        {

            var json = System.IO.File.ReadAllText("MockData/country.json");
            var listCountry = JsonConvert.DeserializeObject<List<Country>>(json);

            return listCountry;
        }
    }
}
