using AutoMapper;
using API.Dtos;
using core.Entities;

namespace API.Profiles;
    public class MappingProfiles : Profile
    {
        public MappingProfiles (){
            CreateMap<Pais, PaisDto>().ReverseMap();
            
            CreateMap<Estado, EstadoDto>().ReverseMap();
            
        }
    }
