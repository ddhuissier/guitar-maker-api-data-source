using StarterKit.Application.Exceptions;
using StarterKit.Domain.Interfaces.Repositories;
using StarterKit.Domain.Models.Data;
using Microsoft.EntityFrameworkCore;
using StarterKit.Infrastructure.Data;

namespace StarterKit.Infrastructure.Repositories
{
    internal sealed class DataTranslationRepositoryAsync : BaseRepositoryAsync<DataTranslation>, IDataTranslationRepositoryAsync
    {
        private readonly DbSet<DataTranslation> _dataTranslation;
        public DataTranslationRepositoryAsync(StarterKitContext dbContext) : base(dbContext)
        {
            _dataTranslation = dbContext.Set<DataTranslation>();
        }

        public async Task<DataTranslation> GetTranslation(string Culture,string Domain, string Tag)
        {
            var translation = await _dataTranslation.FirstOrDefaultAsync(x => x.Culture == Culture && x.Domain == Domain && x.Tag == Tag && x.Active );
            if (translation == null) throw new ApiException("Translation Not Found [{0},{1},{2}]", Culture, Domain, Tag);
            return translation;
        }
        public async Task<List<DataTranslation>> GetTranslation(string Culture, string Domain)
        {
            var translation = await _dataTranslation.Where(x => x.Culture == Culture && x.Domain == Domain && x.Active).ToListAsync();
            if (translation == null) throw new ApiException("Translation Not Found [{0},{1}]", Culture, Domain);
            return translation;
        }
    }
}
