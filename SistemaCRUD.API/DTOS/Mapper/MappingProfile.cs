using AutoMapper;
using SistemaCRUD.API.Models;

namespace SistemaCRUD.API.DTOS.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<EstadoModel, EstadoDTO>().ReverseMap();
            CreateMap<CidadeModel, CidadeDTO>().ReverseMap();
            CreateMap<EmpresaModel, EmpresaDTO>().ReverseMap();
            CreateMap<TipoProdutoModel, TipoProdutoDTO>();
            CreateMap<ProdutoModel, ProdutoDTO>();
        }
    }
}
