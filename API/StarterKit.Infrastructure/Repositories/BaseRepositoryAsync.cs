using StarterKit.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using StarterKit.Infrastructure.Data;

namespace StarterKit.Infrastructure.Repositories
{
    public class BaseRepositoryAsync<TContext,T> : IBaseRepositoryAsync<TContext,T> where TContext : DbContext where T : class 
    {
        private readonly DbFactory _dbFactory;
        private readonly StarterKitContext _dbContext;
        private DbSet<T> _dbSet;

        protected DbSet<T> DbSet
        {
            get => _dbSet ?? (_dbSet = _dbContext.Set<T>());
            //get => _dbSet ?? (_dbSet = _dbFactory.DbContext.Set<T>());
        }

        public BaseRepositoryAsync(StarterKitContext dbContext)//DbFactory dbFactory)
        {
            _dbContext = dbContext;
            //_dbFactory = dbFactory;
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate = null, List<string>? includes = null, params Expression<Func<T, object>>[]? includeProperties)
        {
            IQueryable<T> query = DbSet;

            if (includes != null)
            {
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }

            if (predicate != null) query = query.Where(predicate);

            query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync();
        }
        public virtual async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate = null, List<string>? includes = null, Expression<Func<T, bool>>? keySelector = null)
        {
            IQueryable<T> query = DbSet;

            if (includes != null)
            {
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }
      
            if (keySelector != null) query = query.OrderBy(keySelector);
            if (predicate != null) query = query.Where(predicate);
            
            query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllNoTrackingAsync(List<string>? includes = null)
        {
            IQueryable<T> query = DbSet;

            if (includes != null)
            {
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<T>> GetWhereNoTracking(Expression<Func<T, bool>> predicate, List<string>? includes = null, params Expression<Func<T, object>>[]? includePropertie)
        {
            IQueryable<T> query = DbSet;

            if (includes != null)
            {
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query
                .Where(predicate)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<T>> GetWhereNoTracking(Expression<Func<T, bool>> predicate, List<string>? includes = null, Expression<Func<T, bool>>? keySelector = null)
        {
            IQueryable<T> query = DbSet;

            if (includes != null)
            {
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }
            if (keySelector != null) query = query.OrderBy(keySelector);

            return await query
                .Where(predicate)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            return await _dbContext
                .Set<T>()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetPagedReponseWithPredicateAsync(int pageNumber, int pageSize, Expression<Func<T, bool>> predicate = null)
        {
            IQueryable<T> query = DbSet;

            if (predicate != null) query = query.Where(predicate);

            query = query.Skip((pageNumber - 1) * pageSize);
            query = query.Take(pageSize);
            query = query.AsNoTracking();

            return await query.ToListAsync();
        }

        public async Task<T> AddAsync(T entity, string? userId = null, string? method = null)
        {
            await DbSet.AddAsync(entity);
             await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity, string? userId = null, string? method = null)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

        }

        public async Task DeleteAsync(T entity, string? userId = null, string? method = null)
        {
            DbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
         }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await DbSet
                 .AsNoTracking()
                 .ToListAsync();
        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await DbSet
                .Where(predicate)
                .AsNoTracking()
                .ToListAsync();
        }

        public Task<int> CountAll() => DbSet
            .AsNoTracking()
            .CountAsync();

        public Task<int> CountWhere(Expression<Func<T, bool>> predicate)
            => DbSet
            .AsNoTracking()
            .CountAsync(predicate);
    }
}
