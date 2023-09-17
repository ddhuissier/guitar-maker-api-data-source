using StarterKit.Application.Features.Products.Queries.GetAllProducts;
using AutoMapper;
using StarterKit.Application.Features.Users.Queries.GetAllUsers;
using StarterKit.Domain.Models.Data;

namespace StarterKit.Infrastructure.Profiles
{
    public class GeneralProfile: Profile
    {
        public GeneralProfile()
        {
            // Products
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, GetAllProductsViewModel>().ReverseMap();
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>();
            CreateMap<GetAllUsersViewModel, User>().ReverseMap();
            CreateMap<GetAllUsersQuery, GetAllUsersParameter>();
        }
    }
}
