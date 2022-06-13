using Microsoft.EntityFrameworkCore;
using Produtos.Data.Context;
using Produtos.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Produtos.Data.Respositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly ApiDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(ApiDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll() 
            => _dbSet.AsQueryable();

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> query)
            => _dbSet.Where(query).AsQueryable();

        public async Task<TEntity> Insert(TEntity entity)
        {
            var enty = await _dbSet.AddAsync(entity);
            return enty.Entity;
        }

        public async Task<int> SaveChanges()
            => await _context.SaveChangesAsync();

        public async Task<TEntity> Update(TEntity entity)
            => await Task.FromResult(_dbSet.Update(entity).Entity);
    }
}
