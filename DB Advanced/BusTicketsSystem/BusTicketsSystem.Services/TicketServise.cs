namespace BusTicketsSystem.Services
{
    using AutoMapper;
    using BusTicketsSystem.Data;
    using BusTicketsSystem.Models;
    using BusTicketsSystem.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TicketServise : ITicketService
    {
        private readonly BusTicketsSystemContext context;
        private readonly IMapper mapper;

        public TicketServise(BusTicketsSystemContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void CreateTicket(int customerId, int tripId, decimal price, string seat)
        {
            var ticket = new Ticket
            {
                CustomerId = customerId,
                TripId = tripId,
                Price = price,
                Seat = seat
            };

            this.context.Tickets.Add(ticket);
            this.context.SaveChanges();
        }
    }
}
