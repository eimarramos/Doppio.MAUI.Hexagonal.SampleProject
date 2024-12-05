using AutoMapper;
using Domain.Models;
using Domain.Repositories;
using Infrastructure.Entities;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Api.ShopRepository
{
    public class ShopRepository : IShopRepository
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        public ShopRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<Shop>> GetAll()
        {
            List<ShopEntity> shops = await _context.Shops
                                           .Include(s => s.Categories)
                                           .ToListAsync();

            List<Shop> shopsMapped = _mapper.Map<List<Shop>>(shops);

            return shopsMapped;
        }
    }
}
