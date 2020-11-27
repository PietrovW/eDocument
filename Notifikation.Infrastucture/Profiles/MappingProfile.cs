using AutoMapper;
using Notifikation.Infrastructure.DTO;
using Notifikation.Infrastructure.Entity;

namespace Notifikation.Infrastructure.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<NotifikatItemDTO, NotifikationEntity>()
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message))
                .ForMember(dest => dest.User, opt => opt.Ignore());
        }
    }
}
