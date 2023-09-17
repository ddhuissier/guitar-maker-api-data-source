using System.Data.Entity;
using StarterKit.Domain.Models.Data;

namespace StarterKit.Domain.Interfaces.Repositories
{
    public interface IUserRepositoryAsync : IBaseRepositoryAsync<DbContext, User>
    {

    }
}
