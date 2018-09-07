namespace SoftJail
{
    using AutoMapper;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Globalization;

    public class SoftJailProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public SoftJailProfile()
        {

            CreateMap<CellDto, Cell>();
            CreateMap<DepartmentDto, Department>();
            CreateMap<PrisonerDto, Prisoner>()
                .ForMember(x => x.IncarcerationDate, t => t.MapFrom(p => DateTime.ParseExact(p.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(x => x.ReleaseDate, t => t.MapFrom(p => DateTime.ParseExact(p.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)));

            CreateMap<MailDto, Mail>();

            CreateMap<OfficerDto, Officer>()
                .ForMember(x => x.Weapon, t => t.MapFrom(p => Enum.Parse<Weapon>(p.Weapon)))
                .ForMember(x => x.Position, t => t.MapFrom(p => Enum.Parse<Position>(p.Position)))
                .ForMember(x => x.OfficerPrisoners, t => t.MapFrom(p => p.Prisoners));

            CreateMap<PrisonerIdDto, OfficerPrisoner>()
                .ForMember(x => x.PrisonerId, t => t.MapFrom(p => p.PrisonerId));




        }
    }
}
