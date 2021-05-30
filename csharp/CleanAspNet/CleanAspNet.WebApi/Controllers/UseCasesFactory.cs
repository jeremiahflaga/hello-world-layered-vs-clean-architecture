using CleanAspNet.Domain.UseCases;
using CleanAspNet.Domain.UseCases.SendGreeting;
using Microsoft.Extensions.Logging;

namespace CleanAspNetWebApi
{
    public class UseCasesFactory
    {
        private readonly ILogger logger;
        private readonly ISendGreetingRepository sendGreetingRepository;

        public UseCasesFactory(ILogger<Program> logger, ISendGreetingRepository sendGreetingRepository)
        {
            this.logger = logger;
            this.sendGreetingRepository = sendGreetingRepository;
        }

        private IUseCaseHandler<SendGreetingRequestModel> sendGreetingHandler;
        public IUseCaseHandler<SendGreetingRequestModel> CreateSendGreetingHandler(ISendGreetingPresenter presenter)
        {
            if (sendGreetingHandler == null)
            {
                // Using Pure DI here (or Poor Man's DI)
                // References:
                //   "Understanding the Composition Root" (https://freecontent.manning.com/dependency-injection-in-net-2nd-edition-understanding-the-composition-root/)
                //   "Compose object graphs with confidence" by Mark Seemann (https://blog.ploeh.dk/2011/03/04/Composeobjectgraphswithconfidence/)
                //   "Composition Root" by Mark Seemann (https://blog.ploeh.dk/2011/07/28/CompositionRoot/)
                //   "When to use a DI Container" by Mark Seemann (https://blog.ploeh.dk/2012/11/06/WhentouseaDIContainer/)

                sendGreetingHandler =
                    new LoggingCrossCuttingConcernDecorator<SendGreetingRequestModel>(
                        new SendGreetingHandler(presenter, sendGreetingRepository),
                        logger);
            }
            return sendGreetingHandler;
        }
    }
}
