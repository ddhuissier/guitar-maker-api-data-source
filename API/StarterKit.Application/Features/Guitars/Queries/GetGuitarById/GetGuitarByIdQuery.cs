using StarterKit.Application.Exceptions;
using StarterKit.Application.Wrappers;
using StarterKit.Domain.Interfaces.Repositories;
using MediatR;
using StarterKit.Domain.Models.Data;

namespace StarterKit.Application.Features.Guitars.Queries.GetGuitarById
{
    public class GetGuitarByIdQuery : IRequest<Response<Guitar>>
    {
        public int Id { get; set; }
        public class GetGuitarByIdQueryHandler : IRequestHandler<GetGuitarByIdQuery, Response<Guitar>>
        {
            private readonly IGuitarRepositoryAsync _guitarRepository;
            public GetGuitarByIdQueryHandler(IGuitarRepositoryAsync guitarRepository)
            {
                _guitarRepository = guitarRepository;
            }
            public async Task<Response<Guitar>> Handle(GetGuitarByIdQuery query, CancellationToken cancellationToken)
            {
                var guitar = await _guitarRepository.GetByIdAsync(query.Id);
                if (guitar == null) throw new ApiException($"Guitar Not Found.");
                return new Response<Guitar>(guitar);
            }
        }
    }
}
