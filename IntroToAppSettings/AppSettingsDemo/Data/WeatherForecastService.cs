using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace AppSettingsDemo.Data
{
    public class WeatherForecastService
    {
        private readonly IConfiguration _config;

        /// <summary>
        /// </summary>
        public WeatherForecastService(IConfiguration config)
        {
            _config = config;
        }

        private static readonly string[] Summaries =
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
                                                                          {
                                                                              Date = startDate.AddDays(index),
                                                                              TemperatureC = rng.Next(-20, 55),
                                                                              Summary = Summaries[rng.Next(Summaries.Length)]
                                                                          }).ToArray());
        }
    }
}