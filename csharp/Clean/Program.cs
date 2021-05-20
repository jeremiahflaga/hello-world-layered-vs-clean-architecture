using System;

namespace Clean.Main
{
    using Clean.Data;
    using Clean.Domain;
    using Clean.Presentation;

    class Program
    {
        static void Main(string[] args)
        {
            var greetingsRepository = new GreetingsRepository();
            var greetingsService = new GreetingsService(greetingsRepository);
            var greetingsController = new GreetingsController(greetingsService);

            greetingsController.Execute();
        }
    }
}

namespace Clean.Presentation
{
    using Clean.Domain;

    class GreetingsController
    {
        private readonly GreetingsService greetingsService;

        public GreetingsController(GreetingsService greetingsService)
        {
            this.greetingsService = greetingsService;
        }

        public void Execute()
        {
            var greeting = greetingsService.Execute();
            System.Console.WriteLine(greeting);
        }
    }
}

namespace Clean.Domain
{
    class GreetingsService
    {
        private readonly IGreetingsRepository greetingsRepository;

        public GreetingsService(IGreetingsRepository greetingsRepository)
        {
            this.greetingsRepository = greetingsRepository;
        }
        public string Execute()
        {
            var greeting = greetingsRepository.CreateGreeting();
            return greeting;
        }
    }

    interface IGreetingsRepository
    {
        string CreateGreeting();
    }
}

namespace Clean.Data
{
    using Clean.Domain;

    class GreetingsRepository : IGreetingsRepository
    {
        public string CreateGreeting()
        {
            // Note: the greeting should read from a file or from a daabase, but for simplicity I will hard code it here
            var greeting = "Hello World!";
            return greeting;
        }
    }
}
