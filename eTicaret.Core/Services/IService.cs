using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Core.Services
{
    public interface IService<T> where T : class
    {
        Task<T> GetByIAsync(int id);
       Task<IEnumerable<T>> GetAllAync();
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
        Task RemoveRangeAsync(IEnumerable<T> entities);
    }
}
