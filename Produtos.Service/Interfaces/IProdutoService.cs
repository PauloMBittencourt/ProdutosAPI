using Podutos.Domain.Entities;
using Produtos.Service.DTOs;
using Produtos.Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produtos.Service.Interfaces
{
    public interface IProdutoService : IService
    {
        Task<ResponseService> CreateProduto(CreateProdutoDto prodDto);
        ResponseService<IEnumerable<Produto>> GetProdutosAvailable();
    }
}
