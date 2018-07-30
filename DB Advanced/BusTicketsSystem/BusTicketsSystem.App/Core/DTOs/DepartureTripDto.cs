namespace BusTicketsSystem.App.Core.DTOs
{
    using BusTicketsSystem.Models.Enums;
    using System;

    public class DepartureTripDto
    {
        public string DestinationStationName { get; set; }

        public DateTime DepartureTime { get; set; }

        public TripStatus Status { get; set; }
    }
}
