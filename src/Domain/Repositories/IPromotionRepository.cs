using Domain.Models;

namespace Domain.Repositories
{
    public interface IPromotionRepository
    {
        Task<List<Promotion>> GetAll(int shopId);
    }
}
