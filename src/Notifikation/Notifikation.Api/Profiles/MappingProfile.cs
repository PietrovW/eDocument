using AutoMapper;
using Notifikation.Api.Models;
using Notifikation.Infrastructure.DTO;

namespace Notifikation.Api.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<NotifikationModel, NotifikatItemDTO>()
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message))
                .ForMember(dest => dest.User, opt => opt.Ignore());
        }
    }
}
