using AutoMapper;
using MediatR;
using StarterKit.Application.Wrappers;
using StarterKit.Domain.Interfaces.Repositories;
using System.ComponentModel.DataAnnotations;
using ProductData = StarterKit.Domain.Models.Data;

namespace StarterKit.Application.Features.Product.Commands.CreateProject
{
    public class CreateProductCommand : IRequest<Response<ProductData.Product>>
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Label { get; set; }
        [Required]
        public string UserId { get; set; }
    }
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Response<ProductData.Product>>
    {
        private readonly IProductRepositoryAsync _productRepository;
        private readonly IMapper _mapper;
        public CreateProductCommandHandler(IProductRepositoryAsync productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Response<ProductData.Product>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<ProductData.Product>(request);
            await _productRepository.AddAsync(product, request.UserId, nameof(CreateProductCommand));
            return new Response<ProductData.Product>(product);
        }
    }
}
