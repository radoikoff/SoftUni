namespace BusTicketsSystem.App
{
    using BusTicketsSystem.App.Contracts;
    using BusTicketsSystem.App.Core;
    using BusTicketsSystem.Data;
    using BusTicketsSystem.Services;
    using BusTicketsSystem.Services.Contracts;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using AutoMapper;

    public class StartUp
    {
        public static void Main()
        {
            var service = ConfigureServices();
            Engine engine = new Engine(service);
            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<BusTicketsSystemContext>(options => options.UseSqlServer(Configuration.ConnectionString));

            serviceCollection.AddAutoMapper(cfg => cfg.AddProfile<BusTicketsSystemProfile>());

            serviceCollection.AddTransient<ICommandInterpreter, CommandInterpreter>();
            serviceCollection.AddTransient<IDatabaseInitializerService, DatabaseInitializerService>();
            serviceCollection.AddTransient<IStationService, StationService>();
            serviceCollection.AddTransient<ITripService, TripService>();


            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
