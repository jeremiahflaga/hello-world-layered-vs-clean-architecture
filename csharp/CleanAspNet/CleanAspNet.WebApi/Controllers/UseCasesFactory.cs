using CleanAspNet.Domain.UseCases.SendGreeting;

namespace CleanAspNetWebApi.Controllers
{
    public class UseCasesFactory
    {
        private readonly ISendGreetingRepository sendGreetingRepository;

        public UseCasesFactory(ISendGreetingRepository sendGreetingRepository)
        {
            this.sendGreetingRepository = sendGreetingRepository;
        }

        private SendGreetingHandler sendGreetingHandler;
        public SendGreetingHandler CreateSendGreetingHandler(ISendGreetingPresenter presenter)
        {
            if (sendGreetingHandler == null)
                sendGreetingHandler = new SendGreetingHandler(presenter, sendGreetingRepository);
            return sendGreetingHandler;
        }
    }
}
