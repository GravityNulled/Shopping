using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using StudentsApi.Dtos;
using StudentsApi.Models;

namespace StudentsApi.Profiles
{
    public class IdentificationProfile : Profile
    {
        public IdentificationProfile()
        {
            CreateMap<Identification, IdentificationDto>().ReverseMap();
        }
    }
}