namespace BusTicketsSystem.Services
{
    using BusTicketsSystem.Data;
    using BusTicketsSystem.Services.Contracts;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using AutoMapper;

    public class TripService : ITripService
    {
        private readonly BusTicketsSystemContext context;
        private readonly IMapper mapper;

        public TripService(BusTicketsSystemContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IEnumerable<TModel> ByOriginStationId<TModel>(int stationId) =>
                            this.context.Trips
                                        .Include(t => t.OriginBusStation)
                                        .Where(t => t.OriginBusStationId == stationId)
                                        .AsQueryable()
                                        .ProjectTo<TModel>(mapper.ConfigurationProvider)
                                        .ToArray();

        public IEnumerable<TModel> ByDestinationStationId<TModel>(int stationId) =>
                            this.context.Trips
                                        .Include(t => t.DestinationBusStation)
                                        .Where(t => t.DestinationBusStationId == stationId)
                                        .AsQueryable()
                                        .ProjectTo<TModel>(mapper.ConfigurationProvider)
                                        .ToList();
    }
}
