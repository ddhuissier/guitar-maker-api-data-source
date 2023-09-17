using StarterKit.Domain.Common;

namespace StarterKit.Domain.Interfaces.Services
{
    public interface ITranslationService
    {
        Task<IEnumerable<ViewModelBase>> MatchTranslation(string culture, IEnumerable<ViewModelBase> elements, string domain);
    }
}
