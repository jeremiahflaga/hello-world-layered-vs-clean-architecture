using CleanAspNet.Domain.Entities;
using CleanAspNet.Domain.UseCases.SendGreeting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanAspNet.Data
{
    public class SendGreetingReposiory : ISendGreetingRepository
    {
        //temporary storage
        private static Dictionary<GreetingId, Greeting> greetings = new Dictionary<GreetingId, Greeting>();

        public static UserId johnDoeUserId = UserId.CreateFrom("f8c406a6-45fd-4f7d-a4be-7d2d691eb86e");
        public static UserId janeDoeUserId = UserId.CreateFrom("B7C81404-8A3B-48CF-AA88-2D6496DAEBC5");
        //temporary storage
        private static Dictionary<UserId, User> users = new Dictionary<UserId, User>
        {
            { johnDoeUserId, new User(johnDoeUserId, "John", "Doe") },
            { janeDoeUserId, new User(janeDoeUserId, "Jane", "Doe") }
        };

        public Greeting Get(GreetingId greetingId)
        {
            return greetings[greetingId];
        }

        public User GetUser(UserId userId)
        {
            return users[userId];
        }

        public void Save(Greeting greeting)
        {
            if (greetings.ContainsKey(greeting.Id))
                greetings[greeting.Id] = greeting;
            else
                greetings.Add(greeting.Id, greeting);
        }
    }
}
