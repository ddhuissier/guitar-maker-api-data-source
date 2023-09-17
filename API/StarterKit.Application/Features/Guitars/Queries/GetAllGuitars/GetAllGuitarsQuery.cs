using StarterKit.Application.Wrappers;
using StarterKit.Domain.Interfaces.Repositories;
using AutoMapper;
using MediatR;


namespace StarterKit.Application.Features.Guitars.Queries.GetAllGuitars
{
    public class GetAllGuitarsQuery : IRequest<PagedResponse<IEnumerable<GetAllGuitarsViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllGuitarsQueryHandler : IRequestHandler<GetAllGuitarsQuery, PagedResponse<IEnumerable<GetAllGuitarsViewModel>>>
    {
        private readonly IGuitarRepositoryAsync _guitarRepository;
        private readonly IMapper _mapper;
        public GetAllGuitarsQueryHandler(IGuitarRepositoryAsync guitarRepository, IMapper mapper)
        {
            _guitarRepository = guitarRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllGuitarsViewModel>>> Handle(GetAllGuitarsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllGuitarsParameter>(request);
            var guitar = await _guitarRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var guitarViewModel = _mapper.Map<IEnumerable<GetAllGuitarsViewModel>>(guitar);
            return new PagedResponse<IEnumerable<GetAllGuitarsViewModel>>(guitarViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
