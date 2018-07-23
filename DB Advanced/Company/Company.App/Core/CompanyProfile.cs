using AutoMapper;
using Company.App.Core.DTOs;
using Company.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.App.Core
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Employee, ManagerDto>()
                .ForMember(dest => dest.EmployeesDto, src => src.MapFrom(x => x.ManagerEmployees))
                .ReverseMap();
            CreateMap<Employee, EmployeePersonalInfoDto>().ReverseMap();
        }
    }
}
