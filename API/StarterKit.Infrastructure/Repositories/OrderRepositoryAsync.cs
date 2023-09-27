using StarterKit.Domain.Interfaces.Repositories;
using StarterKit.Domain.Models.Data;
using StarterKit.Infrastructure.Data;


namespace StarterKit.Infrastructure.Repositories
{
    internal sealed class OrderRepositoryAsync : BaseRepositoryAsync< Order>, IOrderRepositoryAsync
    {
        public OrderRepositoryAsync(StarterKitContext dbContext) : base(dbContext)
        {
        }
    }
}
