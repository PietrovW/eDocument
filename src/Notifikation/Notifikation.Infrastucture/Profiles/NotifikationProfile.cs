using AutoMapper;
using Notifikation.Infrastructure.Command;
using Notifikation.Infrastructure.DTO;
using Notifikation.Infrastructure.Entity;

namespace Notifikation.Infrastructure.Profiles
{
    public class NotifikationProfile : Profile
    {
        public NotifikationProfile()
        {
            CreateMap<NotifikatItemDTO, NotifikationEntity>()
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message))
                .ForMember(dest => dest.User, opt => opt.Ignore());

            CreateMap<CreateNotifikationCommand, NotifikationEntity>()
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Notifikation.Message))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.Notifikation.User));
        }
    }
}
