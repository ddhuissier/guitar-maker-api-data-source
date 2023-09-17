using StarterKit.Application.Exceptions;
using StarterKit.Domain.Common;
using StarterKit.Domain.Interfaces.Repositories;
using StarterKit.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace StarterKit.Shared.Services
{
    public class TranslationService: ITranslationService
    {
        private static IDataTranslationRepositoryAsync _dataTranslationRepository;
        public TranslationService(IDataTranslationRepositoryAsync dataTranslationRepository)
        {
            _dataTranslationRepository = dataTranslationRepository;
        }
        public async Task<IEnumerable<ViewModelBase>> MatchTranslation(string culture, IEnumerable<ViewModelBase> elements,string domain)
        {
            var translation = await _dataTranslationRepository.GetTranslation(culture, domain);
            if (translation == null || !translation.Any()) throw new ApiException(@"Translation Not Found {0} {1}.", culture, domain);

            foreach (var element in elements)
            {
                var label = translation?.Find(t => t.Tag == element.Tag)?.Label;
                element.Label = label != null ? label : "Tag unknown";
            }
            return elements;
        }
    }
}
