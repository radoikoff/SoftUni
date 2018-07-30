namespace BusTicketsSystem.Services
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using BusTicketsSystem.Data;
    using BusTicketsSystem.Models;
    using BusTicketsSystem.Services.Contracts;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CustomerService : ICustomerService
    {
        private readonly BusTicketsSystemContext context;
        private readonly IMapper mapper;

        public CustomerService(BusTicketsSystemContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public TModel ById<TModel>(int customerId) =>
                            this.context.Customers
                                        .Include(x => x.BankAccount)
                                        .Where(s => s.Id == customerId)
                                        .AsQueryable()
                                        .ProjectTo<TModel>(mapper.ConfigurationProvider)
                                        .SingleOrDefault();


        public bool Exists(int customerId)
        {
            return this.context.Customers.Find(customerId) != null;
        }

        public void Withdraw(int customerId, decimal price)
        {
            var customer = this.context.Customers.Include(x => x.BankAccount).Where(x => x.Id == customerId).SingleOrDefault();
            customer.BankAccount.Balance -= price;

            this.context.SaveChanges();
        }

        //private Customer GetCustomerById(int customerId) => this.context.Customers.Find(customerId);
    }
}
