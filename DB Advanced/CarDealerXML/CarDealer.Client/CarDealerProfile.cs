namespace CarDealer.Client
{
    using AutoMapper;
    using CarDealer.Client.Dto;
    using CarDealer.Models;

    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<SupplierDto, Supplier>();
            CreateMap<PartDto, Part>();
            CreateMap<CarDto, Car>();
            CreateMap<CustomerDto, Customer>();

        }
    }
}
