using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CIP_1.DataModel;
using CIP_1.Facade;
using CIP_1.ServiceLocator;
using Serilog;

namespace CIP_1.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
       
        public SampleDataController()
    {
       
        Log.Information("I am in the SampleDataController");
    
    }
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        [HttpGet("[action]")]
        public IEnumerable<Subscription> GetSubscriptions(){
            Log.Error("Executing GetSubscription..");
            Log.Warning("THIS IS A WARNING FROM MY CODE...");
          try
          {
              var i=10;
              i=i/0;
          }
          catch (Exception ex)
          {
              
              Log.Fatal(ex.Message);
          }
           ServiceLocatorTool serviceLocator = new ServiceLocatorTool();
            // SubscriptionFacade facade = new SubscriptionFacade(serviceLocator.ObjServiceLocator);
            SubscriptionFacade facade = new SubscriptionFacade();
            var subs = facade.SubscriptionFacade1();
            var results = subs.Result.ToList();
            return results.AsEnumerable();
        }

        [HttpGet("[action]")]
        public IEnumerable<CustomerNote> GetActveUserGuides(){
            Log.Information("Executing GetActveUserGuides...");
            SubscriptionFacade facade = new SubscriptionFacade();
            var subs = facade.ActiveUserGuideFacade();
            var results = subs.Result.ToList();
            return results.AsEnumerable();
        }
        

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
