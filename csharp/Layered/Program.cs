using System;

namespace Layers.Main
{
    using Layers.Presentation;

    class Program
    {
        static void Main(string[] args)
        {
            var greetingsController = new GreetingsController();
            greetingsController.Execute();
        }
    }
}

namespace Layers.Presentation
{
    using Layers.Domain;

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

namespace Layers.Domain
{
    using Layers.Data;

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

namespace Layers.Data
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
