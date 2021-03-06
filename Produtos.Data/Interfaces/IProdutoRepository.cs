using Podutos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produtos.Data.Interfaces
{
    public interface IProdutoRepository : IBaseRepository<Produto>
    {
        Task<Produto?> GetProduto(int CodPrduto);
        Task<Produto?> GetProdutoByName(string Nome);
        IQueryable<Produto?> GetProdutosDisponiveis();
    }
}
