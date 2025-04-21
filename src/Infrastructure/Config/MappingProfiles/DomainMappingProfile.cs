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
            CreateMap<PromotionEntity, Promotion>()
                .ForMember(dest => dest.ExpirationString,
                           opt => opt.MapFrom(src => GetExpirationString(src.Expiration)));
        }

        private string GetExpirationString(DateTimeOffset expiration)
        {
            var now = DateTimeOffset.UtcNow;
            var timeRemaining = expiration - now;

            if (timeRemaining.TotalSeconds <= 0)
            {
                return "Expired";
            }

            if (timeRemaining.TotalHours < 24)
            {
                return $"Expires in {Math.Floor(timeRemaining.TotalHours)} hours";
            }

            return $"Expires in {Math.Floor(timeRemaining.TotalDays)} days";
        }
    }
}
