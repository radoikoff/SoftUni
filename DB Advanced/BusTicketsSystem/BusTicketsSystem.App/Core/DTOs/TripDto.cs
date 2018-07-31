namespace BusTicketsSystem.App.Core.DTOs
{
    using BusTicketsSystem.Models.Enums;
    using System.Collections.Generic;

    public class TripDto
    {
        //public int TripId { get; set; }

        public TripStatus Status { get; set; }

        public string DestinationBusStationName { get; set; }

        public IEnumerable<string> Seats { get; set; }
    }
}
