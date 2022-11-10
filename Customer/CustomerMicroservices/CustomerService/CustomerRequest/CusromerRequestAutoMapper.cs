using AutoMapper;
using Common.Models;
using Common.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerRequest
{
    public class CusromerRequestAutoMapper:Profile
    {
        public CusromerRequestAutoMapper()
        {
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<State, StateDto>().ReverseMap();
            CreateMap<District, DistrictDto>().ReverseMap();
            CreateMap<Registration, RegistrationDto>().ReverseMap();
            CreateMap<ServiceRequestCategorie, ServiceRequestCategorieDto>().ReverseMap();
            CreateMap<ServiceRequest, ServiceRequestDto>().ReverseMap();
            CreateMap<ServiceRequestAssign, ServiceRequestAssignDto>().ReverseMap();
            


        }
    }
}
