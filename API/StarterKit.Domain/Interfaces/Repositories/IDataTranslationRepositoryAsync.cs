using StarterKit.Domain.Models.Data;
using System.Data.Entity;

namespace StarterKit.Domain.Interfaces.Repositories
{
    public interface IDataTranslationRepositoryAsync : IBaseRepositoryAsync< DataTranslation>
    {
        public Task<DataTranslation> GetTranslation(string Culture, string Domain, string Tag);
        public Task<List<DataTranslation>> GetTranslation(string Culture, string Domain);

    }
}
