namespace CleanAspNet.Domain.UseCases.SendGreeting
{
    public interface ISendGreetingPresenter
    {
        void Present(SendGreetingResponseModel responseModel);
        void PresentInputError(string errorMessage);
        void PresentFatalError(string errorMessage = "");
    }
}
