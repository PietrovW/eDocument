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
                .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
                    .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                    .ForMember(dest => dest.xmin, opt => opt.Ignore());
        }
    }
}
