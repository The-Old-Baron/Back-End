namespace OldBarom.Core.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<History, HistoryDTO>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User.UserName));
            CreateMap<Tag, TagDTO>();
            CreateMap<Keywords, KeywordsDTO>();
        }
    }
}