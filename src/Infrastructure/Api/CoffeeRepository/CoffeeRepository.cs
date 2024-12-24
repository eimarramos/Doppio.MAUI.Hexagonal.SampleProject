using AutoMapper;
using Domain.Models;
using Domain.Repositories;
using Infrastructure.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Api.CoffeeRepository
{
    public class CoffeeRepository : ICoffeeRepository
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        public CoffeeRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<Coffee>> GetAllByShopId(int shopId)
        {
            ShopEntity? shop = await _context.Shops
                                             .Include(s => s.Coffees)
                                             .FirstOrDefaultAsync(c => c.Id == shopId);

            if (shop == null) return new List<Coffee>();

            List<CoffeeEntity> coffees = shop.Coffees.ToList();

            return _mapper.Map<List<Coffee>>(coffees);
        }

        public async Task<List<Coffee>> GetTopThreeByShopId(int shopId)
        {
            var shop = await _context.Shops
                                     .Include(s => s.Coffees)
                                     .FirstOrDefaultAsync(c => c.Id == shopId);

            if (shop == null) return new List<Coffee>();

            List<CoffeeEntity> topThreeCoffees = shop.Coffees
                                                     .Take(3)
                                                     .ToList();

            return _mapper.Map<List<Coffee>>(topThreeCoffees);
        }
    }
}
