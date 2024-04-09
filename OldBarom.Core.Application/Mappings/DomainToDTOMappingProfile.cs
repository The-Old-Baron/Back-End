﻿using AutoMapper;
using OldBarom.Core.Application.DTOs.Bases;
using OldBarom.Core.Application.DTOs.MyLinkList;
using OldBarom.Core.Domain.Entities.Basic;
using OldBarom.Core.Domain.Entities.LinkList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBarom.Core.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile() {

            CreateMap<Categories, CategoryDTO>().ReverseMap();
            CreateMap<Cities, CitiesDTO>().ReverseMap();
            CreateMap<CountryStates, CountryStatesDTO>().ReverseMap();
            CreateMap<Countries, CountriesDTO>().ReverseMap();
            CreateMap<Regions, RegionsDTO>().ReverseMap();

        }
    }
}
