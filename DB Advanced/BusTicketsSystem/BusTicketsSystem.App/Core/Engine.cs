namespace BusTicketsSystem.App.Core
{
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using Contracts;
    using Services.Contracts;
    using System.Data.SqlClient;

    public class Engine : IEngine
    {
        private readonly IServiceProvider serviceProvider;

        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Run()
        {
            var initializeService = this.serviceProvider.GetService<IDatabaseInitializerService>();
            initializeService.InitializeDatabase();
            //initializeService.Seed();

            var commandInterpreter = this.serviceProvider.GetService<ICommandInterpreter>();

            while (true)
            {
                try
                {
                    Console.WriteLine("EnterCommand:");
                    string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string result = commandInterpreter.Read(input);
                    Console.WriteLine(result);
                }
                catch (Exception exception) when (exception is SqlException || exception is ArgumentException ||
                                                  exception is InvalidOperationException)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }
}