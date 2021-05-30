using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanAspNet.Domain.UseCases
{
    // Interface used for decorators for cross-cutting concerns as explained by Steven van Deursen in:
    //   "Meanwhile... on the command side of my architecture" (https://blogs.cuttingedge.it/steven/posts/2011/meanwhile-on-the-command-side-of-my-architecture/)
    //   "Meanwhile... on the query side of my architecture"  (https://blogs.cuttingedge.it/steven/posts/2011/meanwhile-on-the-query-side-of-my-architecture/)
    // Also explained by Mark Seemann in:
    //   "Dependency Injection is Loose Coupling" (https://blog.ploeh.dk/2010/04/07/DependencyInjectionisLooseCoupling/)
    //   "Instrumentation with Decorators and Interceptors" (https://blog.ploeh.dk/2010/09/20/InstrumentationwithDecoratorsandInterceptors/)

    // NOTE: This interface is used for both Command and Queries in this application, and so is much simpler than the one metioned in Steven van Deursen's articles.
    // The reason why there is no separate interface for Queries is because we do not return the RequestModel from our UseCase.Process() method.
    // We directly pass the RequestModel to the Presenter, so there is no need to return anything.
    public interface IUseCaseHandler<TRequestModel> // where TRequestModel : IRequestModel
    {
        void Process(TRequestModel requestModel);
    }
}
