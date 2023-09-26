using StarterKit.Infrastructure.Data;


namespace StarterKit.Infrastructure
{
    public class DbFactory : IDisposable
    {
        private bool _disposed;
        private Func<StarterKitContext> _instanceFunc;
        private StarterKitContext _dbContext;
        public StarterKitContext DbContext => _dbContext ?? (_dbContext = _instanceFunc.Invoke());

        public DbFactory(Func<StarterKitContext> dbContextFactory)
        {
            _instanceFunc = dbContextFactory;
        }

        public void Dispose()
        {
            if (!_disposed && _dbContext != null)
            {
                _disposed = true;
                _dbContext.Dispose();
            }
        }
    }
}
