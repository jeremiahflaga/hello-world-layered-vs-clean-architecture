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

        public SendGreetingHandler GetGreetingHandler(ISendGreetingPresenter presenter) => new SendGreetingHandler(presenter, sendGreetingRepository);
    }
}
