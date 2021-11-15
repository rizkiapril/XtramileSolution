using Microsoft.VisualStudio.TestTools.UnitTesting;
using XtramileSolutions.API.Controllers;
using Xunit;
using FakeItEasy;
using XtramileSolutions.API.Models;
using System.Linq;
using XtramileSolutions.API.Provider;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UnitTestXtramileSolutions
{
    [TestClass]
    public class WeatherControllerTest
    {
        [TestMethod]
        public void GetCountry_Return_Number_Of_Country()
        {
            //arrange
            var dataStore = A.Fake<ICountryService>();
            var controller = new CountryController(dataStore);

            //    //act
            var actionResult = controller.GetCountryList();

            //    //assert

            Assert.IsNotNull(actionResult);
        }

        [TestMethod]
        public void GetCity_Return_Number_Of_City()
        {
            //arrange
            var country = "ID";
            var dataStore = A.Fake<ICityService>();
            var controller = new CityController(dataStore);

            //    //act
            var actionResult = controller.GetCity(country);

            //    //assert

            Assert.IsNotNull(actionResult);
        }

        [TestMethod]
        public void GetWeather_Return_Data()
        {
            //arrange
            var city = 1642911;
            var dataStore = A.Fake<IWeatherService>();
            var controller = new WeatherController(dataStore);

            //    //act
            var actionResult = controller.GetWeatherByCity(city);

            //    //assert

            Assert.IsNotNull(actionResult);
        }
    }
}
