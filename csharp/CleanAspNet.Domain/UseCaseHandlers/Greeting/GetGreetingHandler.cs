using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanAspNet.Domain.UseCaseHandlers.Greeting
{
    public class GetGreetingHandler
    {
        public string Execute()
        {
            return "Hello World";
        }
    }

    public interface IGetGreetingPresenter
    {
        void Present(string greetingResponse);
    }
}
