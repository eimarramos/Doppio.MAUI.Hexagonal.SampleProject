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
            List<CoffeeEntity> coffees = await _context.Coffees
                                                        .AsNoTracking()
                                                        .Include(c => c.Shops)
                                                        .Where(c => c.Shops.Any(s => s.Id == shopId))
                                                        .ToListAsync();

            return _mapper.Map<List<Coffee>>(coffees);
        }

        public async Task<List<Coffee>> GetTopThreeByShopId(int shopId)
        {
            List<CoffeeEntity> topThreeCoffees = await _context.Coffees
                                                        .AsNoTracking()
                                                        .Include(c => c.Shops)
                                                        .Where(c => c.Shops.Any(s => s.Id == shopId))
                                                        .Take(3)
                                                        .ToListAsync();

            return _mapper.Map<List<Coffee>>(topThreeCoffees);
        }
    }
}
