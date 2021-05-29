using CleanAspNet.Domain.UseCases.Greeting;
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
        private readonly UseCasesFactory useCasesFactory;

        private IActionResult Result;

        public GetGreetingController(UseCasesFactory useCasesFactory)
        {
            this.useCasesFactory = useCasesFactory;
        }

        [HttpGet]
        public IActionResult Get()
        {
            useCasesFactory.GetGreetingHandler(this).Execute();
            return Result;
        }

        [NonAction]
        public void Present(string greetingResponse)
        {
            Result = Ok(greetingResponse + "!");
        }
    }
}
