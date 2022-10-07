using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Udemy.TodoAppNTier.DataAccess.Interfaces
{
    public interface IRepository<T> where T: class, new()
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);
        Task<T> GetByFilterAsync(Expression<Func<T,bool>> filter, bool asNoTracking = false);
        Task CreateAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
        IQueryable<T> GetQuery();
    }
}