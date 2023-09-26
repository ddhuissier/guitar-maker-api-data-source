using StarterKit.Domain.Interfaces.Repositories;
using StarterKit.Domain.Models.Data;
using StarterKit.Infrastructure.Data;


namespace StarterKit.Infrastructure.Repositories
{
    public class OrderRepositoryAsync : BaseRepositoryAsync<StarterKitContext, Order>, IOrderRepositoryAsync
    {
        public OrderRepositoryAsync(StarterKitContext dbContext) : base(dbContext)
        {
        }
    }
}
