using AutoMapper;
using OCR.Infrastructure.DTO;
using OCR.Infrastructure.Entitys;

namespace OCR.Infrastructure.Profiles
{
    public class OCRProfile : Profile
    {
        public OCRProfile()
    {
        CreateMap<DocumentDTO, DocumentEntity>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.xmin, opt => opt.Ignore());
        }
}
}
