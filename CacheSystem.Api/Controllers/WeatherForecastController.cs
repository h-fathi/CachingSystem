using FG.TradingSystem.Core.Caching;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FG.TradingSystem.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ICacheManager _cacheManager;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, ICacheManager cacheManager)
        {
            _cacheManager = cacheManager;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var rng = new Random();
            var key = _cacheManager.PrepareKeyForShortTermCache(WeatherForecastServicesDefaults.WeatherForecastByIdCacheKey, "test-1");

            var result = await _cacheManager.GetAsync<IEnumerable<WeatherForecast>>(key);
            await _cacheManager.SetAsync(key, result);



            result = await _cacheManager.GetAsync<IEnumerable<WeatherForecast>>(key, () => {
                return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                }).ToArray(); 
            });

            
            return result;
        }
    }
}
