using AutoMapper;
using Podutos.Domain.Entities;
using Produtos.Data.Interfaces;
using Produtos.Service.DTOs;
using Produtos.Service.Helpers;
using Produtos.Service.Interfaces;
using Produtos.Service.Validator;
using System.Net;

namespace Produtos.Service.Services
{
    public class ProdutoService : AbstractService, IProdutoService
    {
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IMapper mapper, IProdutoRepository produtoRepository)
        {
            _mapper = mapper;
            _produtoRepository = produtoRepository;
        }

        public async Task<ResponseService> CreateProduto(CreateProdutoDto prodDto) 
        {
            if (!ExecutarValidacao(new CreateProdutoDtoValidator(), prodDto))
                return GeneratePreconditionFailedServiceResponse(ObterNotificacoes().First());

            var produto = _mapper.Map<Produto>(prodDto);

            var ReturnedProduto = _produtoRepository.GetProdutoByName(produto.Nome_Prod);

            if (ReturnedProduto.Result != null)
            {
                return GenerateBadRequestServiceResponse("Ocorreu um erro desconhecido");
            }

            await _produtoRepository.Insert(produto);

            await _produtoRepository.SaveChanges();

            return GenerateSuccessServiceResponse();
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
