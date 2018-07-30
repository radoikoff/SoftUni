using System.Collections.Generic;

namespace BusTicketsSystem.Services.Contracts
{
    public interface ITripService
    {
        IEnumerable<TModel> ByOriginStationId<TModel>(int stationId);
        IEnumerable<TModel> ByDestinationStationId<TModel>(int stationId);
    }
}
