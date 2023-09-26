
using MediatR;
using StarterKit.Application.Exceptions;
using StarterKit.Application.Wrappers;
using StarterKit.Domain.Interfaces.Repositories;
using System.ComponentModel.DataAnnotations;

namespace StarterKit.Application.Features.Product.Commands.DeleteProductById
{
    public class DeleteProductByIdCommand : IRequest<Response<int>>
    {
        [Required]
        public int Id { get; set; }
        public string UserId { get; set; }

        public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, Response<int>>
        {
            private readonly IProductRepositoryAsync _productRepository;
            public DeleteProductByIdCommandHandler(IProductRepositoryAsync productRepository)
            {
                _productRepository = productRepository;
            }
            public async Task<Response<int>> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
            {
                var product = await _productRepository.GetByIdAsync(command.Id);
                if (product == null) throw new ApiException($"Product Not Found.");

                await _productRepository.DeleteAsync(product, command.UserId, nameof(DeleteProductByIdCommand));
                return new Response<int>(product.Id);
            }
        }
    }
}
