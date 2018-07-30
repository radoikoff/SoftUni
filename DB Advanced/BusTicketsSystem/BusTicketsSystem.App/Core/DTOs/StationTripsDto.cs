namespace BusTicketsSystem.App.Core.DTOs
{
    using System.Collections.Generic;

    public class StationTripsDto
    {
        public string StationName { get; set; }

        public string TownName { get; set; }

        public ICollection<ArrivalsTripDto> ArrivalTrips { get; set; }

        public ICollection<DepartureTripDto> DepartureTrips { get; set; }
    }
}
