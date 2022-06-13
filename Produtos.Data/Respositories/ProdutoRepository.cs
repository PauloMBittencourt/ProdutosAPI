using Microsoft.EntityFrameworkCore;
using Podutos.Domain.Entities;
using Produtos.Data.Context;
using Produtos.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produtos.Data.Respositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        private readonly DbSet<Produto> _dbSet;

        public ProdutoRepository(ApiDbContext context) : base(context)
        {
            _dbSet = context.Set<Produto>();
        }

        public async Task<Produto?> GetProduto(int CodPrduto) => await _dbSet.FirstOrDefaultAsync(x => x.ProdutoId == CodPrduto);

        public IQueryable<Produto?> GetProdutosDisponiveis() => _dbSet.Where(x => x.Qtde_estoque != 0);

        public async Task<Produto?> GetProdutoByName(string Nome) => await _dbSet.FirstOrDefaultAsync(x => x.Nome_Prod == Nome);
    }
}
