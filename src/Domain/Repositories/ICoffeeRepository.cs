using Domain.Models;

namespace Domain.Repositories
{
    public interface ICoffeeRepository
    {
        Task<List<Coffee>> GetAllByShopId(int shopId);
        Task<List<Coffee>> GetTopThreeByShopId(int shopId);
    }
}
