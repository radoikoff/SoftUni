namespace Company.Services
{
    using System;
    using Data;
    using Contracts;
    using Microsoft.EntityFrameworkCore;

    public class DbInitializerService : IDbInitializerService
    {
        private readonly CompanyContext context;

        public DbInitializerService(CompanyContext context)
        {
            this.context = context;
        }

        public void InitializeDatabase()
        {
            this.context.Database.Migrate();
        }
    }
}
