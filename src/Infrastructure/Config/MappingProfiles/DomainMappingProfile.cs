using AutoMapper;
using Domain.Models;
using Infrastructure.Entities;

namespace Infrastructure.Config.MappingProfiles
{
    public class DomainMappingProfile : Profile
    {
        public DomainMappingProfile()
        {
            CreateMap<CategoryEntity, Category>();
            CreateMap<ShopEntity, Shop>()
            .ForMember(dest => dest.CategoriesString,
                       opt => opt.MapFrom(src => string.Join(" • ", src.Categories.Select(c => c.Name))));
            CreateMap<CoffeeEntity, Coffee>();
            CreateMap<CartEntity, Cart>();
            CreateMap<CartDetailEntity, CartDetail>();
        }
    }
}
