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
    public class CartaoRepository : BaseRepository<Cartao>, ICartaoRepository 
    {
        private readonly DbSet<Cartao> _dbSet;
        public CartaoRepository(ApiDbContext context) : base(context)
        {
            _dbSet = context.Set<Cartao>();
        }
    }
}
