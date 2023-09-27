using StarterKit.Application.Features.Products.Queries.GetAllProducts;
using AutoMapper;
using StarterKit.Application.Features.Users.Queries.GetAllUsers;
using StarterKit.Domain.Models.Data;
using StarterKit.Application.Features.Product.Commands.CreateProduct;
using StarterKit.Application.Features.Product.Commands.UpdateProduct;

namespace StarterKit.Infrastructure.Profiles
{
    public class GeneralProfile: Profile
    {
        public GeneralProfile()
        {
            
            CreateMap<GetAllUsersViewModel, User>().ReverseMap();
            CreateMap<GetAllUsersQuery, GetAllUsersParameter>();

            // Products
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, GetAllProductsViewModel>().ReverseMap();
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>();
            CreateMap<GetAllUsersQuery, GetAllUsersParameter>();
            CreateMap<CreateProductCommand,Product>().ReverseMap();
            CreateMap<UpdateProductCommand, Product>().ReverseMap();
        }
    }
}
