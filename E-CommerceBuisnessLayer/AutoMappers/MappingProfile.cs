using AutoMapper;
using E_CommerceBuisnessLayer.DTOs;
using E_CommerceBuisnessLayer.Models;


namespace E_CommerceBuisnessLayer.AutoMappers
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();

            CreateMap<BestSelling, BestSellingDto>()
                .ForMember(dest => dest.Product,
                 src => src.MapFrom(src => src.Product))
                .ReverseMap();

            //Map Retrieval Best sellings
            CreateMap<BestSelling, BestSellingReadDto>()
           .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product.Title));


            // Map Product to ProductDto
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.Category, srs => srs
                .MapFrom(srs => srs.Category))
                .ForMember(dest => dest.Brand, srs => srs.MapFrom(src => src.Brand))
                .ReverseMap();

            CreateMap<Brand, BrandDTO>()
              .ForMember(dest => dest.Category, src => src
              .MapFrom(src => src.Category.CategoryName)).ReverseMap();


            CreateMap<User, CreateUserDto>().ReverseMap();

            CreateMap<User, UserDto>();

            CreateMap<Address, CreatAddressDto>().ReverseMap();

            CreateMap<Review, CreateReviewDto>().ReverseMap();

            CreateMap<Review, ReviewDetails>()
                .ForMember(dest => dest.UserName, src => src.MapFrom(src => src.User.fullName)).ReverseMap();
                
            CreateMap<Cart, CartDto>().ReverseMap();
        }

    }
}
