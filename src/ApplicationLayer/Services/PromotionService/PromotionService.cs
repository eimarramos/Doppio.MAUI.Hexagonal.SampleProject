using Domain.Models;
using Domain.Repositories;

namespace ApplicationLayer.Services.PromotionService
{
    public class PromotionService
    {
        private readonly IPromotionRepository _promotionRepository;

        public PromotionService(IPromotionRepository promotionRepository)
        {
            _promotionRepository = promotionRepository;
        }

        public async Task<List<Promotion>> GetAll()
        {
            return await _promotionRepository.GetAll();
        }
    }
}
