using CleanAspNet.Domain.Entities;
using CleanAspNet.Domain.UseCases.SendGreeting;
using System;

namespace CleanAspNetWebApi.Controllers
{
    public class SendGreetingInputData
    {
        // InputData properties must have publid setters so that ASP.NET can put value into them (protected or internal properties does not work)
        public string ReceiverId { get; set; } = CleanAspNet.Data.SendGreetingReposiory.janeDoeUserId.Value.ToString(); // set default to Jane Doe's Id
        public string DateTimeSent { get; set; }
        public string TimeZoneSentFrom { get; set; }

        public SendGreetingRequestModel ToRequestModel(Guid loggedInUserId)
        {
            return new SendGreetingRequestModel(UserId.CreateFrom(loggedInUserId), UserId.CreateFrom(ReceiverId), DateTimeOffset.Parse(DateTimeSent), TimeZoneSentFrom);
        }
    }

    internal class SendGreetingRequestModelBuilder
    {
        SendGreetingInputData inputData;
        Guid senderId;

        private SendGreetingRequestModelBuilder(SendGreetingInputData inputData)
        {
            this.inputData = inputData;
        }

        public static SendGreetingRequestModelBuilder CreateFrom(SendGreetingInputData inputData)
        {
            return new SendGreetingRequestModelBuilder(inputData);
        }

        public SendGreetingRequestModelBuilder WithSender(Guid senderId) 
        {
            this.senderId = senderId;
            return this;
        }

        public SendGreetingRequestModel Build()
        {
            return new SendGreetingRequestModel(
                UserId.CreateFrom(senderId),
                UserId.CreateFrom(inputData.ReceiverId),
                DateTimeOffset.Parse(inputData.DateTimeSent),
                inputData.TimeZoneSentFrom);
        }
    }
}