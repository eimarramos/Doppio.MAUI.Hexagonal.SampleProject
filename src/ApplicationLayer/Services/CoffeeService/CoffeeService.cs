using Domain.Models;
using Domain.Repositories;

namespace ApplicationLayer.Services.CoffeeService
{
    public class CoffeeService
    {
        private readonly ICoffeeRepository _coffeeRepository;

        public CoffeeService(ICoffeeRepository coffeeRepository)
        {
            _coffeeRepository = coffeeRepository;
        }

        public async Task<List<Coffee>> GetAllByShopId(int shopId)
        {
            return await _coffeeRepository.GetAllByShopId(shopId);
        }

        public async Task<List<Coffee>> GetTopThreeByShopId(int shopId)
        {
            return await _coffeeRepository.GetTopThreeByShopId(shopId);
        }
    }
}
