using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Sunny", "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private static readonly WeatherForecast[] cities = new WeatherForecast[]
        {
        new WeatherForecast
            {
                Date = new DateTime(2020, 2, 25, 16, 41, 48),
                TemperatureC = 21,
                Summary = Summaries[0],
                ZipCode = "5300252"
            },
        new WeatherForecast
            {
                Date = DateTime.Now,
                TemperatureC = new Random().Next(-20, 55),
                Summary = Summaries[new Random().Next(0, Summaries.Length)],
                ZipCode = "5300251"
            },
        new WeatherForecast
            {
                Date = new DateTime(2020, 2, 25, 16, 41, 48),
                TemperatureC = new Random().Next(-20, 55),
                Summary = Summaries[new Random().Next(0, Summaries.Length)],
                ZipCode = "5300250"
            }
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public WeatherForecast Index()
        {
            return new WeatherForecast
            {
                Date = new DateTime(2020, 2, 25, 16, 41, 48),
                TemperatureC = 21,
                Summary = Summaries[0]
            };
        }

        [HttpGet("{zipcode}")]
        public WeatherForecast getByZipCode(string zipcode)
        {
            return Array.Find(cities, p => p.ZipCode == zipcode);
        }
    }
}
