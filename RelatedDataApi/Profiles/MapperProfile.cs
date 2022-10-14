using AutoMapper;
using DTOS;
using Models;

namespace RelatedDataApi.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //Comic
            CreateMap<ComicDTO, Comic>();
            CreateMap<Comic, ComicDTO>();
            //SuperHeroe
            CreateMap<SuperHeroeDTO, SuperHeroe>();
            CreateMap<SuperHeroe, SuperHeroeDTO>();
            //Team
            CreateMap<TeamDTO, Team>();
            CreateMap<Team, TeamDTO>();
        }
    }
}
