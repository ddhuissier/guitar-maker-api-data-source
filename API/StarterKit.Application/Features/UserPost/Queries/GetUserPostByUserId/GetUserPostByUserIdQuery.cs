using StarterKit.Application.Exceptions;
using StarterKit.Application.Wrappers;
using MediatR;
using StarterKit.Domain.Interfaces.Services;
using StarterKit.Domain.Models.Responses;

namespace StarterKit.Application.Features.UserPosts.Queries.GetUserPostById
{
    public class GetUserPostByUserIdQuery : IRequest<Response<List<UserPost>>>
    {
        public int Id { get; set; }
        public class GetUserPostByUserIdQueryHandler : IRequestHandler<GetUserPostByUserIdQuery, Response<List<UserPost>>>
        {
            private readonly IExternalDataService _service;
            public GetUserPostByUserIdQueryHandler(IExternalDataService service)
            {
                _service = service;
            }
            public async Task<Response<List<UserPost>>> Handle(GetUserPostByUserIdQuery query, CancellationToken cancellationToken)
            {
                var post = await _service.GetUserPostAsync(query.Id);
                if (post == null) throw new ApiException($"User Post Not Found.");
                return new Response<List<UserPost>>(post);
            }
        }
    }
}
