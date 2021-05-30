using CleanAspNet.Domain.Entities;

namespace CleanAspNet.Domain.UseCases.SendGreeting
{
    public interface ISendGreetingRepository
    {
        User GetUser(UserId userId);
        void Save(Greeting greeting);
        Greeting Get(GreetingId greetingId);
    }
}
