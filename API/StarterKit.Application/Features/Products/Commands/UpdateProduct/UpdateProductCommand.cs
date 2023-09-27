
using AutoMapper;
using MediatR;
using StarterKit.Application.Exceptions;
using StarterKit.Application.Wrappers;
using StarterKit.Domain.Interfaces;
using StarterKit.Domain.Interfaces.Repositories;
using System.ComponentModel.DataAnnotations;
using ProductData = StarterKit.Domain.Models.Data;

namespace StarterKit.Application.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<Response<ProductData.Product>>
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Label { get; set; }
        [Required]
        public string UserId { get; set; }
    }
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Response<ProductData.Product>>
    {
        private readonly IProductRepositoryAsync _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateProductCommandHandler(IProductRepositoryAsync productRepository,

            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Response<ProductData.Product>> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
            {
                throw new ApiException($"Product Not Found.");
            }
            else
            {
                var product = _mapper.Map<ProductData.Product>(command);
                if (product.Id != 0)
                {
                    _productRepository.Update(product, command.UserId);
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                }

                return new Response<ProductData.Product>(product);
            }
        }
    }
}
