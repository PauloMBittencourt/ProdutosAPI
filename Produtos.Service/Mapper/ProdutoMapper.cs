using AutoMapper;
using Podutos.Domain.Entities;
using Produtos.Service.DTOs;

namespace Produtos.Service.Mapper
{
    public class ProdutoMapper : Profile
    {
        public ProdutoMapper()
        {
            CreateMap<CreateProdutoDto, Produto>()
                .ReverseMap();
        }
    }
}
