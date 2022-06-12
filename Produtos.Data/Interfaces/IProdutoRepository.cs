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
        IQueryable<Produto?> GetProdutosDisponiveis(int CodProduto);
    }
}
