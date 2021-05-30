using CleanAspNet.Domain.Entities;
using System;

namespace CleanAspNet.Domain.UseCases.SendGreeting
{
    public class SendGreetingResponseModel
    {
        public string SenderFullName { get; private set; }
        public string ReceiverFullName { get; private set; }
        public DateTimeOffset DateTimeSent { get; private set; }
        public string TimeZoneSentFrom { get; private set; }

        public static SendGreetingResponseModel CreateFrom(Greeting greeting)
        {
            return new SendGreetingResponseModel
            {
                SenderFullName = greeting.Sender.FullName,
                ReceiverFullName = greeting.Receiver.FullName,
                DateTimeSent = greeting.DateTimeSent,
                TimeZoneSentFrom = greeting.TimeZoneSentFrom
            };
        }
    }
}