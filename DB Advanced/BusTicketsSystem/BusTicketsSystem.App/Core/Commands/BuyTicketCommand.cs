using BusTicketsSystem.App.Contracts;
using BusTicketsSystem.App.Core.DTOs;
using BusTicketsSystem.Services.Contracts;
using System;
using System.Linq;

namespace BusTicketsSystem.App.Core.Commands
{
    public class BuyTicketCommand : ICommand
    {
        private readonly ICustomerService customerService;
        private readonly ITripService tripService;
        private readonly ITicketService ticketService;

        public BuyTicketCommand(ICustomerService customerService, ITripService tripService, ITicketService ticketService)
        {
            this.customerService = customerService;
            this.tripService = tripService;
            this.ticketService = ticketService;
        }

        public string Execute(string[] data)
        {
            //buy-ticket {customer ID} {Trip ID} {Price} {Seat}

            int customerId = int.Parse(data[0]);
            int tripId = int.Parse(data[1]);
            decimal price = decimal.Parse(data[2]);
            string seat = data[3];

            if (price < 0)
            {
                throw new ArgumentException("Invalid price");
            }

            var customerExists = this.customerService.Exists(customerId);

            if (!customerExists)
            {
                throw new ArgumentException($"Customer with Id {customerId} not found!");
            }

            var tripExists = this.tripService.Exists(tripId);

            if (!tripExists)
            {
                throw new ArgumentException($"Trip with Id {tripId} not found!");
            }


            var customer = this.customerService.ById<CustomerDto>(customerId);
            var trip = this.tripService.ById<TripDto>(tripId);

            if (customer.Balance < price)
            {
                throw new ArgumentException($"Insufficient amount of money for customer {customer.FullName} with bank account number {customer.AccountNumber}");
            }

            if (trip.Seats.Contains(seat))
            {
                throw new ArgumentException($"Requested seat {seat} is already occupied!");
            }

            this.customerService.Withdraw(customerId, price);
            this.ticketService.CreateTicket(customerId, tripId, price, seat);

            return $"Customer {customer.FirstName + " " + customer.LastName} bought ticket for trip {tripId} for ${price} on seat {seat}";
        }
    }
}
