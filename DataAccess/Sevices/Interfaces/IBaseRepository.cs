using ApplicationCore.Entities.Abstract;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Sevices.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<List<T>> GetByDefaultListAsync(Expression<Func<T, bool>> expression);
        Task<T> GetByDefaultAsync(Expression<Func<T, bool>> expression);
        Task<T> GetByIdAsync(int Id);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);

        Task<List<TResault>> GetFiltredListAsync<TResault>
            (
                Expression<Func<T, TResault>> select,
                Expression<Func<T, bool>> where = null,
                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                Func<IQueryable<T>, IIncludableQueryable<T, object>> join = null

            );
    }

}
