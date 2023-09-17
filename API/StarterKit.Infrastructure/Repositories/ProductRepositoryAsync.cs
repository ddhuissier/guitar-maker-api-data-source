using Microsoft.EntityFrameworkCore;
using StarterKit.Domain.Interfaces.Repositories;
using StarterKit.Domain.Models.Data;
using StarterKit.Infrastructure.Data;


namespace StarterKit.Infrastructure.Repositories
{
    public class ProductRepositoryAsync : BaseRepositoryAsync<StarterKitContext, Product>, IProductRepositoryAsync
    {
        public ProductRepositoryAsync(StarterKitContext dbContext) : base(dbContext)
        {
        }
    }
}
