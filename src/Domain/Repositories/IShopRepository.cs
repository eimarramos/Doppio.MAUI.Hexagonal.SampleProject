using Domain.Models;

namespace Domain.Repositories
{
    public interface IShopRepository
    {
        Task<List<Shop>> GetAll();
    }
}
