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

            var product = _mapper.Map<Produto>(prodDto);

            var ReturnedProduto = _produtoRepository.GetProdutoByName(product.Nome_Prod);

            if (ReturnedProduto.Result != null)
            {
                return GenerateBadRequestServiceResponse("Ocorreu um erro desconhecido");
            }

            await _produtoRepository.Insert(product);

            await _produtoRepository.SaveChanges();

            return GenerateSuccessServiceResponse();
        }

        public ResponseService<IEnumerable<GetProdutoDto>> GetProdutosAvailable()
        {
            var products = _produtoRepository.GetProdutosDisponiveis();

            if (!products.Any())
            {
                return GenerateBadRequestServiceResponse<IEnumerable<GetProdutoDto>>("Ocorreu um erro desconhecido");
            }

            var receivedProducts = _mapper.Map<IEnumerable<GetProdutoDto>>(products);

            return GenerateSuccessServiceResponse(receivedProducts.AsEnumerable());
        }

        public async Task<ResponseService<ContractProdutoDto>> ContratarProduto(ContractProdutoDto prodDto)
        {
            var product = _mapper.Map<Produto>(prodDto);

            var client = new HttpClient();

            HttpResponseMessage response = await client.PostAsJsonAsync("http://sv-dev-01.pareazul.com.br:8080/api/gateways/compras", prodDto.Cartoes);


            if (response.IsSuccessStatusCode)
            {
                product.DecreaseEstoque(prodDto.Qtde_Comprada); 
                await _produtoRepository.SaveChanges();
                return GenerateSuccessServiceResponse(prodDto);
            }

            return GenerateBadRequestServiceResponse<ContractProdutoDto>("Ocorreu um erro desconhecido");
        }
    }
}
