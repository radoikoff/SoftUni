namespace BusTicketsSystem.Services
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using BusTicketsSystem.Data;
    using BusTicketsSystem.Services.Contracts;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StationService : IStationService
    {
        private readonly BusTicketsSystemContext context;
        private readonly IMapper mapper;

        public StationService(BusTicketsSystemContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public bool Exists(int stationId)
        {
            return this.context.BusStations.Find(stationId) != null;
        }

        public TModel ById<TModel>(int stationId) =>
                            this.context.BusStations
                                        .Include(s => s.Town)
                                        .Where(s => s.Id == stationId)
                                        .AsQueryable()
                                        .ProjectTo<TModel>(mapper.ConfigurationProvider)
                                        .SingleOrDefault();
    }
}
