namespace BusTicketsSystem.App.Core.DTOs
{
    using BusTicketsSystem.Models.Enums;
    using System;

    public class ArrivalsTripDto
    {
        public string OriginStationName { get; set; }

        public DateTime ArrivalTime { get; set; }

        public TripStatus Status { get; set; }
    }
}
