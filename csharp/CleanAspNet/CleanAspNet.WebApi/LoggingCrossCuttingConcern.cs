using CleanAspNet.Domain.UseCases;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanAspNetWebApi
{
    public class LoggingCrossCuttingConcernDecorator<TRequestModel> : IUseCaseHandler<TRequestModel>
    {
        private readonly IUseCaseHandler<TRequestModel> decorated;
        private readonly ILogger logger;

        public LoggingCrossCuttingConcernDecorator(IUseCaseHandler<TRequestModel> decorated, ILogger logger)
        {
            this.decorated = decorated;
            this.logger = logger;
        }

        public void Process(TRequestModel requestModel)
        {
            logger.LogInformation($"Starting use case handler {decorated.GetType().FullName}");
            decorated.Process(requestModel);
            logger.LogInformation($"Ending use case handler {decorated.GetType().FullName}");
        }
    }
}
