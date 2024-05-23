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