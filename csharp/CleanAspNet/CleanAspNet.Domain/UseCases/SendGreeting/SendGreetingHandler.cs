using CleanAspNet.Domain.Entities;
using System;

namespace CleanAspNet.Domain.UseCases.SendGreeting
{
    public class SendGreetingHandler : IUseCaseHandler<SendGreetingRequestModel>
    {
        private readonly ISendGreetingPresenter presenter;
        private readonly ISendGreetingRepository repository;

        public SendGreetingHandler(ISendGreetingPresenter presenter, ISendGreetingRepository repository)
        {
            this.presenter = presenter;
            this.repository = repository;
        }

        public void Process(SendGreetingRequestModel requestModel)
        {
            try
            {
                var receiver = repository.GetUser(requestModel.ReceiverId);
                if (receiver == null)
                {
                    presenter.PresentInputError("Please provide receiver of greeting");
                }
                else
                {
                    var sender = repository.GetUser(requestModel.SenderId);

                    var greetingId = GreetingId.CreateNew();
                    var greeting = new Greeting(greetingId, sender, receiver, requestModel.DateTimeSent, requestModel.TimeZoneSentFrom);
                    repository.Save(greeting);

                    var newlyCreatedGreeting = repository.Get(greetingId);
                    var responseModel = SendGreetingResponseModel.CreateFrom(newlyCreatedGreeting);
                    presenter.Present(responseModel);
                }
            }
            catch (Exception ex)
            {
                presenter.PresentFatalError();
            }
        }
    }
}
