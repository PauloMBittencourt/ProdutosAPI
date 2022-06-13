using Microsoft.AspNetCore.Mvc;
using Podutos.Domain.Entities;
using Produtos.Service.DTOs;
using Produtos.Service.Interfaces;
using System.Net;

namespace Produtos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        /// <summary>
        /// Endpoint para pegar todos produtos disponiveis
        /// </summary>
        /// <returns></returns>
        [HttpGet("PegarTodosDisponiveis")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult PegarTodosDisponiveis()
        {
            var response = _produtoService.GetProdutosAvailable();

            if (response.Success)
                return Ok(response.Value);
            return BadRequest(response.Message);
        }

        /// <summary>
        /// Endpoint para adicionar produtos
        /// </summary>
        /// <param name="prodDto"></param>
        /// <returns></returns>
        [HttpPost("AdicionarProduto")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.PreconditionFailed)]
        public async Task<IActionResult> AdicionarProdutos(CreateProdutoDto prodDto)
        {
            var response = await _produtoService.CreateProduto(prodDto);
            if (response.Success)
                return Ok(response);
            if (response.StatusCode == HttpStatusCode.PreconditionFailed)
                return StatusCode(StatusCodes.Status412PreconditionFailed, response.Message);
            else
                return BadRequest(response.Message);
        }

        /// <summary>
        /// Endpoint para comprar produtos
        /// </summary>
        /// <param name="prodDto"></param>
        /// <returns></returns>
        [HttpPost("ComprarProduto")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> ComprarProduto(ContractProdutoDto prodDto)
        {
            var response = await _produtoService.ContratarProduto(prodDto);
            if (response.Success)
                return Ok(response);
            else
                return BadRequest(response.Message);
        }
    }
}
