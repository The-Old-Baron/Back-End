using OldBarom.Core.Application.DTOs.Base;
using OldBarom.Core.Application.DTOs.Systempunk;
using OldBarom.Core.Domain.Model.Systempunk;
using OldBarom.Core.Domain.Model.Base;
using AutoMapper;
namespace OldBarom.Core.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<History, HistoryDTO>();
            CreateMap<Tags, TagDTO>();
            CreateMap<Keywords, KeywordsDTO>();
        }
    }
}