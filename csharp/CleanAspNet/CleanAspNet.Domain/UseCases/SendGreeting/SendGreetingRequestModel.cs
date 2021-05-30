using CleanAspNet.Domain.Entities;
using System;

namespace CleanAspNet.Domain.UseCases.SendGreeting
{
    public class SendGreetingRequestModel
    {
        public UserId SenderId { get; private set; }
        public UserId ReceiverId { get; private set; }
        public DateTimeOffset DateTimeSent { get; private set; }
        public string TimeZoneSentFrom { get; private set; }

        public SendGreetingRequestModel(UserId  senderId, UserId receiverId, DateTimeOffset dateTimeSent, string timezone)
        {
            SenderId = senderId;
            ReceiverId = receiverId;
            DateTimeSent = dateTimeSent;
            TimeZoneSentFrom = timezone;
        }

        //public static GetGreetingRequestModel Create(UserId receiverId, DateTimeOffset dateTimeSent, string timezone)
        //{
        //    return new GetGreetingRequestModel
        //    {
        //        ReceiverId = receiverId,
        //        DateTimeSent = dateTimeSent,
        //        TimeZoneSentFrom = timezone
        //    };
        //}
    }
}
