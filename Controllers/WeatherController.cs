#region Imports
using Microsoft.AspNetCore.Mvc;
using CLIMATE_DATA_BRAZIL.Services;
using CLIMATE_DATA_BRAZIL.Models;
using CLIMATE_DATA_BRAZIL.Controllers;
using MongoDB.Driver.Core.Operations;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization.Infrastructure;
#endregion

namespace CLIMATE_DATA_BRAZIL.Controllers
{
    #region Controller & Route -Variables
    [Controller]
    [Route("~/api/[controller]")]
    #endregion

    #region Weather Controller
    public class WeatherController : Controller
    {
        #region region MongoDBServices Variable
        private readonly MongoDBServices _mongodbServices;
        #endregion

        #region Setting _mongodbServices To mongodbServices
        public WeatherController(MongoDBServices mongodbServices)
        {
            _mongodbServices = mongodbServices;
        }
        #endregion

        #region Http Get Weather
        [HttpGet]
        public async Task<List<WeatherModel>> GetWeather()
        {
            return await _mongodbServices.GetWeatherAsync();
        }
        #endregion

        #region Http Post Weather
        [HttpPost]
        public async Task<IActionResult> PostWeather(WeatherModel weatherModel)
        {
            await _mongodbServices.CreateWeatherAsync(weatherModel);
            return CreatedAtAction(nameof(GetWeather), new { id = weatherModel.Id }, weatherModel);
        }
        #endregion
    }
    #endregion
}
