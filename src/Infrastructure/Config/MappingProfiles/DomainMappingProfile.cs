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
            CreateMap<ShopEntity, Shop>();
        }
    }
}
