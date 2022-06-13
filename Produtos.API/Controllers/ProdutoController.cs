using Microsoft.AspNetCore.Mvc;
using Podutos.Domain.Entities;
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
        /// Endpoint para cadastro de pessoa no elenco
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
    }
}
