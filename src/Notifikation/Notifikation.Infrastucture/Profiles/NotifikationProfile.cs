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

            CreateMap<NotifikationEntity, NotifikatItemDTO>()
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));

            CreateMap<UserDTO, UserEntity>()
                .ForMember(dest => dest.DateCreated, opt => opt.Ignore())
                .ForMember(dest => dest.DateUpdate, opt => opt.Ignore())
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<UserEntity, UserDTO>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
