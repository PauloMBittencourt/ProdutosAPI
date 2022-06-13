using AutoMapper;
using Podutos.Domain.Entities;
using Produtos.Data.Interfaces;
using Produtos.Service.Helpers;
using Produtos.Service.Interfaces;
using System.Net;

namespace Produtos.Service.Services
{
    public class ProdutoService : AbstractService, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async ResponseService CreateProduto(Produto prod) 
        {
            var filmes = _produtoRepository.GetProdutoByName(prod.Nome_Prod);

            if (filmes != null) 
            {
                return GenerateBadRequestServiceResponse("Ocorreu um erro desconhecido");
            }
        }

        public ResponseService<IEnumerable<Produto>> GetProdutosAvailable()
        {
            var products = _produtoRepository.GetProdutosDisponiveis();

            if (!products.Any())
            {
                return GenerateBadRequestServiceResponse<IEnumerable<Produto>>("Ocorreu um erro desconhecido");
            }

            return GenerateSuccessServiceResponse(products.AsEnumerable());
        }
    }
}
