using CleanAspNet.Domain.UseCases.Greeting;

namespace CleanAspNetWebApi.Controllers
{
    public class UseCasesFactory
    {
        public IGetGreetingHandler GetGreetingHandler(IGetGreetingPresenter presenter) => new GetGreetingHandler(presenter);
    }
}
