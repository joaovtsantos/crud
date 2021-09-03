namespace DataAcess.Interfaces
{
    using DapperExtensions;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IRepository<T> where T : class
    {
        T GetById(Guid id);
        IEnumerable<T> GetAll();
        Guid Insert(T entity, IDbTransaction transaction = null, int? commandTimeout = null);
        void Update(T entity, IDbTransaction transaction = null, int? commandTimeout = null);
        void Delete(T entity, IDbTransaction transaction = null, int? commandTimeout = null);
        Task<T> GetByIdAsync(Guid Id, IDbTransaction transaction = null, int? commandTimeout = null);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, IList<ISort> sort = null, IDbTransaction transaction = null, int? commandTimeout = null);
        Task<dynamic> InsertAsync(T entity, IDbTransaction transaction = null, int? commandTimeout = default(int?));
        Task<bool> UpdateAsync(T entity, IDbTransaction transaction = null, int? commandTimeout = null);
        Task<bool> DeleteAsync(T entity, IDbTransaction transaction = null, int? commandTimeout = null);
        Task<PaginationResponse<T>> GetAllAsyncPagination(int pageSize, int pageIndex, string sort, string direction, string tableName = "");
    }
}
