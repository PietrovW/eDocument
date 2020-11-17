using AutoMapper;
using Notifikation.Api.Models;
using Notifikation.Infrastructure.DTO;

namespace Notifikation.Api.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<NotifikationModel, NotifikatItemDTO>();
        }
    }
}
