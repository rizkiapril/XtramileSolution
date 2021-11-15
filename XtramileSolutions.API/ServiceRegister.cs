using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XtramileSolutions.API.Provider;

namespace XtramileSolutions.API
{
    public static class ServiceRegister
    {
        public static void RegisterDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ICountryService, CountryProvider>();
            services.AddScoped<ICityService, CityProvider>();
            services.AddScoped<IWeatherService, WeatherProvider>();


        }
    }
}
