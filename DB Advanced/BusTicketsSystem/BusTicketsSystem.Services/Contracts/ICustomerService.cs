using System;
using System.Collections.Generic;
using System.Text;

namespace BusTicketsSystem.Services.Contracts
{
    public interface ICustomerService
    {
        bool Exists(int customerId);
        TModel ById<TModel>(int customerId);
        void Withdraw(int customerId, decimal price);
    }
}
