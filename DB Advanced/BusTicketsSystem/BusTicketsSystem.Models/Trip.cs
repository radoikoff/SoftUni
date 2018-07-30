namespace BusTicketsSystem.Models
{
    using BusTicketsSystem.Models.Enums;
    using System;
    using System.Collections.Generic;

    public class Trip
    {
        //departure time, arrival time, status, origin bus station, destination bus station, bus company

        public int Id { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public TripStatus Status { get; set; }

        public int OriginBusStationId { get; set; }
        public BusStation OriginBusStation { get; set; }

        public int DestinationBusStationId { get; set; }
        public BusStation DestinationBusStation { get; set; }

        public int BusCompanyId { get; set; }
        public BusCompany BusCompany { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
