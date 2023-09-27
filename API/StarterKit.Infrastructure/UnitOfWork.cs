using Microsoft.EntityFrameworkCore;
using StarterKit.Domain.Interfaces;
using StarterKit.Infrastructure.Data;

namespace StarterKit.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StarterKitContext _dbContext;

        public UnitOfWork(StarterKitContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }
        public void Rollback()
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                }
            }
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
