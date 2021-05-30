using System;

namespace CleanAspNet.Domain.Entities
{
    public class Greeting
    {
        public GreetingId Id { get; set; }

        public User Sender { get; private set; }
        public User Receiver { get; private set; }

        public DateTimeOffset DateTimeSent { get; private set; }
        public string TimeZoneSentFrom { get; private set; }

        public Greeting(GreetingId id, User sender, User receiver, DateTimeOffset dateTimeSent, string timeZoneSentFrom)
        {
            Id = id;
            Sender = sender;
            Receiver = receiver;
            DateTimeSent = dateTimeSent;
            TimeZoneSentFrom = timeZoneSentFrom;
        }

        public bool IsSuspicious => 
            string.Concat(Sender.FirstName, " ", Sender.LastName, " ", Receiver.FirstName, " ", Receiver.LastName)
            .ToLowerInvariant()
            .Contains("screwtape");
    }
}
