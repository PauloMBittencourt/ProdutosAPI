using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produtos.Data.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> Insert(TEntity entity);
        Task<int> SaveChanges();
        Task<TEntity> Update(TEntity entity);
    }
}
