using CleanAspNet.Domain.UseCaseHandlers.Greeting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanAspNetWebApi.Controllers
{
    [ApiController]
    [Route("api/greeting")]
    public class GetGreetingController : ControllerBase, IGetGreetingPresenter
    {
        private readonly ILogger<WeatherForecastController> logger;
        private readonly GetGreetingHandler getGreetingHandler;

        private string ViewModel;

        public GetGreetingController(ILogger<WeatherForecastController> logger, GetGreetingHandler getGreetingHandler)
        {
            this.logger = logger;
            this.getGreetingHandler = getGreetingHandler;
        }

        [HttpGet]
        public string Get()
        {
            getGreetingHandler.Execute();
            return ViewModel;
        }

        [NonAction]
        public void Present(string greetingResponse)
        {
            ViewModel = greetingResponse + "!";
        }
    }
}
