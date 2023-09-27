using StarterKit.Domain.Interfaces.Repositories;
using StarterKit.Domain.Models.Data;
using StarterKit.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace StarterKit.Infrastructure.Repositories
{
    internal sealed class OrderRepositoryAsync : BaseRepositoryAsync< Order>, IOrderRepositoryAsync
    {
        private readonly DbSet<Order> _orders;
        public OrderRepositoryAsync(StarterKitContext dbContext) : base(dbContext)
        {
            _orders = dbContext.Set<Order>();
        }
        public async Task<int> GetDeliveredOrderCount()
        {
            return await _orders.Where(o => o.Status == OrderStatus.Delivered).CountAsync();
        }
    }
}
