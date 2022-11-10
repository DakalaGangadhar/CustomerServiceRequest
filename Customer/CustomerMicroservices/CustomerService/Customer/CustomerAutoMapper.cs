using AutoMapper;
using Common.Models;
using Common.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer
{
    public class CustomerAutoMapper : Profile
    {
        public CustomerAutoMapper()
        {
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<State, StateDto>().ReverseMap();
            CreateMap<District, DistrictDto>().ReverseMap();
            CreateMap<Registration, RegistrationDto>().ReverseMap();
        }
    }
}