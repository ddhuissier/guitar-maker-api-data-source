using System.Linq.Expressions;

namespace StarterKit.Domain.Interfaces.Repositories
{
    public interface IBaseRepositoryAsync<T>  where T : class 
    {
        Task<T> GetByIdAsync(int id);
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate = null, List<string>? includes = null, params Expression<Func<T, object>>[]? includeProperties);
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate = null, List<string>? includes = null, Expression<Func<T, bool>>? keySelector = null);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetPagedReponseAsync(int pageNumber, int pageSize);
        Task<IReadOnlyList<T>> GetPagedReponseWithPredicateAsync(int pageNumber, int pageSize, Expression<Func<T, bool>> predicate = null);
        T Add(T entity, string? userId = null);
        void Update(T entity, string? userId = null);
        void Delete(T entity, string? userId = null);
        Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);
        Task<int> CountAll();
        Task<int> CountWhere(Expression<Func<T, bool>> predicate);
    }
}
