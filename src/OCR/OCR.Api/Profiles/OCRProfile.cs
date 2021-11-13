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
                .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));
        }
    }
}
