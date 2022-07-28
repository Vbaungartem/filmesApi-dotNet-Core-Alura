using AutoMapper;
using filmesAPI.Data.Dtos;
using filmesAPI.Models;

namespace filmesAPI.Profiles
{
    public class FilmeProfile : Profile
    {

        public FilmeProfile()
        {
            CreateMap<CreateFilmeDto, Filme>();
            CreateMap<UpdateFilmeDto, Filme>();
            CreateMap<Filme, ReadFilmeDto>();
        }
    }
}
