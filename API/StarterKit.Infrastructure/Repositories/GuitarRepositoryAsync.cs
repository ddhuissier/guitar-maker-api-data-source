using Microsoft.EntityFrameworkCore;
using StarterKit.Domain.Interfaces.Repositories;
using StarterKit.Domain.Models.Data;
using StarterKit.Infrastructure.Data;


namespace StarterKit.Infrastructure.Repositories
{
    internal sealed class GuitarRepositoryAsync : BaseRepositoryAsync< Guitar>, IGuitarRepositoryAsync
    {

        public GuitarRepositoryAsync(StarterKitContext dbContext) : base(dbContext)
        {
        }
    }
}
