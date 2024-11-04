using AutoMapper;
using Solidariza.Domain.DTO;
using Solidariza.Domain.DTO.Usuario;
using Solidariza.Domain.Models;
using Solidariza.Domain.Models.Pagination;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap(typeof(PagedResult<>), typeof(PagedResultDTO<>)).ReverseMap();

        CreateMap<Usuario, UserDTO>();
        CreateMap<Doador, DoadorDTO>();
        //CreateMap<KeywordFilter, FilterKeywordDTO>();
        CreateMap<FilterKeywordDTO, KeywordFilter>().ReverseMap();
    }
}