# Cache Manager System

Async task base caching system for in-memory, distributed, hybrid cache

This library is a Caching System implementation for .Net Core which will remove developers' pain to write cache manager for each .NET Core and .NET project.

First of all register what you want to use:
         services.AddMemoryCachingSystem();
         
         //services.AddDistributedCachingSystem();
         
         //services.AddClusterCachingSystem();
         
Then you can use it easily like:

           var key = _cacheManager.PrepareKeyForShortTermCache(WeatherForecastByIdCacheKey, "test-1");
           //var key = _cacheManager.PrepareKeyForShortTermCache("weatherforecast.byId.{0}", "test-1");
           
           //get by key
           var result = await _cacheManager.GetAsync<IEnumerable<WeatherForecast>>(key);
           //set data by key
           await _cacheManager.SetAsync(key, result);
           
         
Or like this you can tell if not exsit then do it and set to cache:

          var result = await _cacheManager.GetAsync<IEnumerable<WeatherForecast>>(key, () => {
                return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                }).ToArray(); 
            });
        
This library includes following notable features:
This library can be run on any .NET Core or .NET application which has .NET Core 3.1, .NET Standard 2.1 and .NET 5.0 support.

It has providing the Cache Manager with In-memory, Distributed Redis, Hybrid EasyCache cache support.

