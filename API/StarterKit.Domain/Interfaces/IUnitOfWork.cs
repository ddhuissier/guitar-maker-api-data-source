
namespace StarterKit.Domain.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
