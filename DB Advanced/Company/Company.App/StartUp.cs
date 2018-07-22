namespace Company.App
{
    using Services;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using Services.Contracts;
    using Company.App.Core;
    using Company.App.Core.Contracts;
    using Company.App.Core.Controllers;
    using AutoMapper;

    public class StartUp
    {
        public static void Main()
        {
            IServiceProvider service = ConfigureService();
            Engine engine = new Engine(service);
            engine.Run();
        }

        private static IServiceProvider ConfigureService()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<CompanyContext>(opt => opt.UseSqlServer(Configuration.ConnectionString));
            serviceCollection.AddAutoMapper(c => c.AddProfile<CompanyProfile>());
            serviceCollection.AddTransient<IDbInitializerService, DbInitializerService>();
            serviceCollection.AddTransient<ICommandInterpreter, CommandInterpreter>();
            serviceCollection.AddTransient<IEmployeeController, EmployeeController>();

            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
