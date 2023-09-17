using StarterKit.Domain.Models.Data;
using StarterKit.Domain.Models.Responses;

namespace StarterKit.Domain.Interfaces.Services
{
    public interface IExternalDataService
    {

        Task<List<UserPost>?> GetUserPostAsync(int id);
    }
}
