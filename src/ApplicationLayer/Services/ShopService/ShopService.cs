using Domain.Models;
using Domain.Repositories;

namespace ApplicationLayer.Services.ShopService
{
    public class ShopService
    {
        private readonly IShopRepository _shopRepository;

        public ShopService(IShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }

        public async Task<List<Shop>> GetAll()
        {
            return await _shopRepository.GetAll();
        }
    }
}
