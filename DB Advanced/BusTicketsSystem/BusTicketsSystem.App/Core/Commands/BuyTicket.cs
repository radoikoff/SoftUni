using BusTicketsSystem.App.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusTicketsSystem.App.Core.Commands
{
    public class BuyTicket : ICommand
    {
        public string Execute(string[] data)
        {
            //buy-ticket {customer ID} {Trip ID} {Price} {Seat}

            int customerId = int.Parse(data[0]);
            int tripId = int.Parse(data[1]);
            decimal price = decimal.Parse(data[2]);
            string seat = data[3];



            throw new NotImplementedException();
        }
    }
}
