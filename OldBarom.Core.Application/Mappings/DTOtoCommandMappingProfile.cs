using AutoMapper;
using OldBarom.Core.Application.DTOs.Systempunk;
using OldBarom.Core.Domain.Entities.Systempunk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBarom.Core.Application.Mappings
{
    public class DTOtoCommandMappingProfile : Profile
    {
        public DTOtoCommandMappingProfile()
        {
            CreateMap<HistoryDTO, History>();
            CreateMap<TagDTO, Tag>();
        }
    }
}
