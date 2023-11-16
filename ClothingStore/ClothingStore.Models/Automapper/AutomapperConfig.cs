using AutoMapper;
using ClothingStore.Domain.Entities;
using ClothingStore.Models.DTO.BrandDTOs;
using ClothingStore.Models.DTO.CategoryDTOs;
using ClothingStore.Models.DTO.ColorDTOs;
using ClothingStore.Models.DTO.ProductDTOs;
using ClothingStore.Models.DTO.ShoppingCartDTO;
using ClothingStore.Models.DTO.UserDTOs;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Models.Automapper
{
    [ExcludeFromCodeCoverage]
    public class AutomapperConfig
    {
        public static IMapper Configure(IMapper mapper)
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserRequestDTO, User>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ForMember(dest => dest.ShoppingCarts, opt => opt.Ignore())
                    .ForMember(dest => dest.Session, opt => opt.Ignore());
                cfg.CreateMap<User, UserResponseDTO>().ReverseMap();
                cfg.CreateMap<User, UserResponseDTO>();
                cfg.CreateMap<User, UserUpdateDTO>();
                cfg.CreateMap<UserUpdateDTO, User>()
                    .ForMember(dest => dest.Roles, opt => opt.Ignore());
                cfg.CreateMap<Brand, BrandResponseDTO>().ReverseMap();
                cfg.CreateMap<Color, ColorResponseDTO>().ReverseMap();
                cfg.CreateMap<Category, CategoryResponseDTO>().ReverseMap();
                cfg.CreateMap<Product, ProductResponseDTO>().ReverseMap();
                cfg.CreateMap<ShoppingCart, ShoppingCartResponseDTO>()
                    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                    .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products.Select(p => new ProductInCartDTO
                    {
                        Id = p.Id,
                        Name = p.Name,
                        // Otros mapeos de propiedades según sea necesario
                    })));
            });

            return config.CreateMapper();
        }

    }
}
