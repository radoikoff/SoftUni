using System.Collections.Generic;

namespace BusTicketsSystem.Services.Contracts
{
    public interface ITripService
    {
        bool Exists(int tripId);
        TModel ById<TModel>(int tripId);
        IEnumerable<TModel> ByOriginStationId<TModel>(int stationId);
        IEnumerable<TModel> ByDestinationStationId<TModel>(int stationId);
    }
}
