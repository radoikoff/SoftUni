namespace BusTicketsSystem.App
{
    using AutoMapper;
    using BusTicketsSystem.App.Core.DTOs;
    using BusTicketsSystem.Models;
    using System.Linq;

    public class BusTicketsSystemProfile : Profile
    {
        public BusTicketsSystemProfile()
        {
            CreateMap<Trip, ArrivalsTripDto>()
                .ForMember(dest => dest.OriginStationName, opt => opt.MapFrom(x => x.OriginBusStation.Name));

            CreateMap<Trip, DepartureTripDto>()
                .ForMember(dest => dest.DestinationStationName, opt => opt.MapFrom(x => x.DestinationBusStation.Name));

            CreateMap<BusStation, StationDto>();

            CreateMap<Customer, CustomerDto>()
                .ForMember(dest => dest.Balance, opt => opt.MapFrom(x => x.BankAccount.Balance));

            CreateMap<Trip, TripDto>()
                .ForMember(dest => dest.Seats, opt => opt.MapFrom(x => x.Tickets.Select(s => s.Seat)));

        }
    }
}
