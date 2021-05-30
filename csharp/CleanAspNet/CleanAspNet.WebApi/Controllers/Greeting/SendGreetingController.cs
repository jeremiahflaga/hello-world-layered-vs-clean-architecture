using CleanAspNet.Domain.UseCases.SendGreeting;
using Microsoft.AspNetCore.Http;
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
    public class SendGreetingController : ControllerBase, ISendGreetingPresenter
    {
        private readonly UseCasesFactory useCasesFactory;

        private IActionResult Result;

        // TODO_JBOY: change this someday; this value should be coming from the Authentication service
        private Guid LoggedInUserId = CleanAspNet.Data.SendGreetingReposiory.johnDoeUserId.Value;

        public SendGreetingController(UseCasesFactory useCasesFactory)
        {
            this.useCasesFactory = useCasesFactory;
        }

        #region Controller
        // NOTE: To display more descriptive request body for Swagger page, properties of InputData must be public
        [HttpPost]
        public IActionResult Execute([FromBody] SendGreetingInputData inputData)
        {
            var requestModel = SendGreetingRequestModelBuilder
                .CreateFrom(inputData)
                .WithSender(LoggedInUserId)
                .Build();
            useCasesFactory.GetGreetingHandler(this).Execute(requestModel);
            return Result;
        }
        #endregion

        #region Presenter
        [NonAction]
        public void Present(SendGreetingResponseModel responseModel)
        {
            Result = Ok($"Hello {responseModel.ReceiverFullName}! | from {responseModel.SenderFullName} | sent {responseModel.DateTimeSent}");
        }

        [NonAction]
        public void PresentInputError(string errorMessage)
        {
            Result = BadRequest(errorMessage);
        }

        [NonAction]
        public void PresentFatalError(string errorMessage = "")
        {
            Result = StatusCode(StatusCodes.Status500InternalServerError);
        }
        #endregion
    }
}
