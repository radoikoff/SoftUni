namespace BusTicketsSystem.App
{
    using AutoMapper;
    using BusTicketsSystem.App.Core.DTOs;
    using BusTicketsSystem.Models;

    public class BusTicketsSystemProfile : Profile
    {
        public BusTicketsSystemProfile()
        {
            CreateMap<Trip, ArrivalsTripDto>()
                .ForMember(dest => dest.OriginStationName, opt => opt.MapFrom(x => x.OriginBusStation.Name));

            CreateMap<Trip, DepartureTripDto>()
                .ForMember(dest => dest.DestinationStationName, opt => opt.MapFrom(x => x.DestinationBusStation.Name));

            CreateMap<BusStation, StationDto>();

        }
    }
}
