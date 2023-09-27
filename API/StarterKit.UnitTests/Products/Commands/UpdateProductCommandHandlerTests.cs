using AutoMapper;
using Moq;
using StarterKit.Application.Features.Product.Commands.CreateProduct;
using StarterKit.Application.Features.Product.Commands.UpdateProduct;
using StarterKit.Domain.Interfaces;
using StarterKit.Domain.Interfaces.Repositories;
using StarterKit.Domain.Models.Data;
using StarterKit.Infrastructure.Profiles;

namespace StarterKit.UnitTests.Products.Commands
{
    public class UpdateProductCommandHandlerTests
    {
        private readonly Mock<IProductRepositoryAsync> _productRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandlerTests()
        {
            _productRepositoryMock = new();
            _unitOfWorkMock = new();
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new GeneralProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        [Fact]
        public async Task Handle_Should_ReturnSuccedResult_WithId()
        {
            // Arrange
            var command = new UpdateProductCommand()
            {
                Id = 1,
                Label = "Product1",
                UserId = "User1"
            };
            var handler = new UpdateProductCommandHandler(
                _productRepositoryMock.Object,
                _mapper,
                _unitOfWorkMock.Object);
            // Act
            var result = await handler.Handle(command, default);

            // Assert
            Assert.True(result.Succeeded);
        }
        
    }
}