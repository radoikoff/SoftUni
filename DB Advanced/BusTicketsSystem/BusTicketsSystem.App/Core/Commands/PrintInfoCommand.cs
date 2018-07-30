namespace BusTicketsSystem.App.Core.Commands
{
    using Contracts;
    using BusTicketsSystem.Services.Contracts;
    using System;
    using System.Linq;
    using System.Text;
    using DTOs;

    public class PrintInfoCommand : ICommand
    {
        private readonly ITripService tripService;
        private readonly IStationService stationService;

        public PrintInfoCommand(ITripService tripService, IStationService stationService)
        {
            this.tripService = tripService;
            this.stationService = stationService;
        }


        public string Execute(string[] data)
        {
            int stationId = int.Parse(data[0]);

            bool stationExists = this.stationService.Exists(stationId);

            if (!stationExists)
            {
                throw new ArgumentException($"Bus station with Is {stationId} not found!");
            }

            var station = this.stationService.ById<StationDto>(stationId);

            var tripsArrivals = this.tripService.ByDestinationStationId<ArrivalsTripDto>(stationId);

            var tripsDepartures = this.tripService.ByOriginStationId<DepartureTripDto>(stationId);


            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{station.Name}, {station.TownName}");
            sb.AppendLine("Arrivals:");

            foreach (var trip in tripsArrivals)
            {
                sb.AppendLine($"From {trip.OriginStationName} | Arrive at: {trip.ArrivalTime} | Status: {trip.Status}");
            }

            sb.AppendLine("Departures:");

            foreach (var trip in tripsDepartures)
            {
                sb.AppendLine($"To {trip.DestinationStationName} | Depart at: {trip.DepartureTime} | Status {trip.Status}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
