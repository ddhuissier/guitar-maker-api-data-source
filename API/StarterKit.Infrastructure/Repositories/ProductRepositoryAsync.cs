using StarterKit.Domain.Interfaces.Repositories;
using StarterKit.Domain.Models.Data;
using StarterKit.Infrastructure.Data;


namespace StarterKit.Infrastructure.Repositories
{
    internal sealed class ProductRepositoryAsync : BaseRepositoryAsync<Product>, IProductRepositoryAsync
    {
        public ProductRepositoryAsync(StarterKitContext dbContext) : base(dbContext)
        {
        }
    }
}
