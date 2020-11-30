using AutoMapper;
using OCR.Api.Models;
using OCR.Infrastructure.DTO;

namespace OCR.Api.Profiles
{
    public class OCRProfile : Profile
    {
        public OCRProfile()
        {
            CreateMap<DocumentModel, DocumentDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));
        }
    }
}
