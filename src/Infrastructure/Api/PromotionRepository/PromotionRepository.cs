using AutoMapper;
using Domain.Models;
using Domain.Repositories;
using Infrastructure.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Api.PromotionRepository
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        public PromotionRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Promotion>> GetAll(int shopId)
        {
            List<PromotionEntity> promotions = await _context.Promotions
                                                       .AsNoTracking()
                                                       .Include(p => p.Shop)
                                                       .Include(p => p.Coffee)
                                                       .ToListAsync();

            List<Promotion> promotionsMapped = _mapper.Map<List<Promotion>>(promotions);

            return promotionsMapped;
        }
    }
}
