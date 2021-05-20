using System;

namespace Layered.Main
{
    using Layered.Presentation;

    class Program
    {
        static void Main(string[] args)
        {
            var greetingsController = new GreetingsController();
            greetingsController.Execute();
        }
    }
}

namespace Layered.Presentation
{
    using Layered.Domain;

    class GreetingsController
    {
        public void Execute()
        {
            var greetingsService = new GreetingsService();
            var greeting = greetingsService.Execute();

            System.Console.WriteLine(greeting);
        }
    }
}

namespace Layered.Domain
{
    using Layered.Data;

    class GreetingsService
    {
        public string Execute()
        {
            var greetingsRepository = new GreetingsRepository();
            var greeting = greetingsRepository.CreateGreeting();
            return greeting;
        }
    }
}

namespace Layered.Data
{
    class GreetingsRepository
    {
        public string CreateGreeting()
        {
            // Note: the greeting should read from a file or from a daabase, but for simplicity I will hard code it here
            var greeting = "Hello World!";
            return greeting;
        }
    }
}
