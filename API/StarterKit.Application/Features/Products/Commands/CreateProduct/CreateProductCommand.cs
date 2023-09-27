using AutoMapper;
using MediatR;
using StarterKit.Application.Wrappers;
using StarterKit.Domain.Interfaces;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateProductCommandHandler(IProductRepositoryAsync productRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<ProductData.Product>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<ProductData.Product>(request);
            _productRepository.Add(product, request.UserId);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return new Response<ProductData.Product>(product);
        }
    }
}
