using StarterKit.Application.Exceptions;
using StarterKit.Application.Wrappers;
using StarterKit.Domain.Interfaces;
using StarterKit.Domain.Interfaces.Repositories;
using StarterKit.Domain.Models.Data;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace StarterKit.Application.Features.Project.Queries.GetTranslationByCultureDomainTagQuery
{
    public class GetTranslationByCultureDomainTagQuery : IRequest<Response<DataTranslation>>
    {
        [Required]
        public string Culture { get; set; }
        [Required]
        public string Domain { get; set; }
        [Required]
        public string Tag { get; set; }
        public class GetTranslationByCultureDomainTagQueryHandler : IRequestHandler<GetTranslationByCultureDomainTagQuery, Response<DataTranslation>>
        {
            private readonly IDataTranslationRepositoryAsync _dataTranslationRepository;
            public GetTranslationByCultureDomainTagQueryHandler(IDataTranslationRepositoryAsync dataTranslationRepository)
            {
                _dataTranslationRepository = dataTranslationRepository;
            }
            public async Task<Response<DataTranslation>> Handle(GetTranslationByCultureDomainTagQuery query, CancellationToken cancellationToken)
            {
                var translation = await _dataTranslationRepository.GetTranslation(query.Culture, query.Domain, query.Tag);
                if (translation == null) throw new ApiException("Translation Not Found [{0},{1},{2}]", query.Culture, query.Domain, query.Tag);
                return new Response<DataTranslation>(translation);
            }
        }
    }
}
