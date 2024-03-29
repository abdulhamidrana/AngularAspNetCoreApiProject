﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IRepository.IRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AccountManagement.Controllers
{

    //NLog Testing:
    //[ApiController]
    //[Route("[controller]")]
    //public class WeatherForecastController : ControllerBase
    //{
    //    private readonly ILoggerManager _logger;
    //    public WeatherForecastController(ILoggerManager logger)
    //    {
    //        _logger = logger;
    //    }
    //    [HttpGet]
    //    public IEnumerable<string> Get()
    //    {
    //        _logger.LogInfo("Here is info message from the controller.");
    //        _logger.LogDebug("Here is debug message from the controller.");
    //        _logger.LogWarn("Here is warn message from the controller.");
    //        _logger.LogError("Here is error message from the controller.");
    //        return new string[] { "value1", "value2" };
    //    }
    //}


    //RepositoryWrapper Service Testing
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IRepositoryWrapper _wrapper;
        public WeatherForecastController(IRepositoryWrapper wrapper)
        {
            _wrapper = wrapper;
        }


        [HttpGet]
        public IEnumerable<string> Get()
        {
            var domesticAccounts = _wrapper.Account.FindByCondition(a => a.AccountType.Equals("Domestic"));
            var owners = _wrapper.Owner.FindAll();
            return new string[] { "value1", "value2" };
        }
    }





    //[ApiController]
    //[Route("[controller]")]
    //public class WeatherForecastController : ControllerBase
    //{
    //    private static readonly string[] Summaries = new[]
    //    {
    //        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    //    };

    //    private readonly ILogger<WeatherForecastController> _logger;

    //    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    //    {
    //        _logger = logger;
    //    }

    //    [HttpGet]
    //    public IEnumerable<WeatherForecast> Get()
    //    {
    //        var rng = new Random();
    //        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //        {
    //            Date = DateTime.Now.AddDays(index),
    //            TemperatureC = rng.Next(-20, 55),
    //            Summary = Summaries[rng.Next(Summaries.Length)]
    //        })
    //        .ToArray();
    //    }
    //}
}
