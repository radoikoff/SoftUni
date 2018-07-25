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
                .ForMember(dest => dest.EmployeesDto, from => from.MapFrom(x => x.ManagerEmployees))
                .ReverseMap();
            CreateMap<Employee, EmployeePersonalInfoDto>().ReverseMap();
            CreateMap<Employee, EmployeeWithManagerDto>()
                //.ForMember(dest => dest.ManagerFirstName, from => from.MapFrom(x => x.Manager.FirstName))
                //.ForMember(dest => dest.ManagerLastName, from => from.MapFrom(x => x.Manager.LastName))
                .ReverseMap();
        }
    }
}
