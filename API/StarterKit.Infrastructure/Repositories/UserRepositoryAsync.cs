using StarterKit.Domain.Interfaces.Repositories;
using StarterKit.Domain.Models.Data;
using StarterKit.Infrastructure.Data;


namespace StarterKit.Infrastructure.Repositories
{
    public class UserRepositoryAsync : BaseRepositoryAsync<StarterKitContext, User>, IUserRepositoryAsync
    {
        public UserRepositoryAsync(StarterKitContext dbContext) : base(dbContext)
        {
        }
    }
}
