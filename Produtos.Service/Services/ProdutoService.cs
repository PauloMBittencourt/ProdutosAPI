using AutoMapper;
using Podutos.Domain.Entities;
using Produtos.Data.Interfaces;
using Produtos.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produtos.Service.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IMapper mapper, IProdutoRepository produtoRepository)
        {
            _mapper = mapper;
            _produtoRepository = produtoRepository;
        }

        public Task<IEnumerable<Produto>> GetProdutosAvailable()
        {
            var products = _produtoRepository.GetProdutosDisponiveis();]

            if (products is null)
            {
                return Task.FromResult(new ResponseService(System.Net.HttpStatusCode.BadRequest, "Ocorreu um erro desconhecido"));
            }
        }
    }
}
