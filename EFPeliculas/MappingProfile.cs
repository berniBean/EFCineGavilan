
using AutoMapper;
using EFPeliculas.Entidades;
using EFPeliculas.Entidades.DTO;

namespace EFPeliculas
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Genero, GeneroDTO>();
            CreateMap<Actor, ActorDTO>();

            CreateMap<Cine, CineDTO>()
                .ForMember(dto => dto.Latitud, ent => ent.MapFrom(prop => prop.Ubicacion.Y))
                .ForMember(dto => dto.Longitud, ent => ent.MapFrom(prop => prop.Ubicacion.X));
        }
    }
}
