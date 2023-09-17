using Microsoft.EntityFrameworkCore;
using StarterKit.Domain.Interfaces.Repositories;
using StarterKit.Domain.Models.Data;
using StarterKit.Infrastructure.Data;


namespace StarterKit.Infrastructure.Repositories
{
    public class GuitarRepositoryAsync : BaseRepositoryAsync<StarterKitContext, Guitar>, IGuitarRepositoryAsync
    {

        public GuitarRepositoryAsync(StarterKitContext dbContext) : base(dbContext)
        {
        }
    }
}
