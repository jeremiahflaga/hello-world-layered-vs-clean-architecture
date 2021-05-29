using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanAspNet.Domain.UseCases.Greeting
{
    public class GetGreetingHandler : IGetGreetingHandler
    {
        private readonly IGetGreetingPresenter presenter;

        public GetGreetingHandler(IGetGreetingPresenter presenter)
        {
            this.presenter = presenter;
        }

        public void Execute()
        {
            presenter.Present("Hello World");
        }
    }

    public interface IGetGreetingHandler
    {
        void Execute();
    }

    public interface IGetGreetingPresenter
    {
        void Present(string greetingResponse);
    }
}
