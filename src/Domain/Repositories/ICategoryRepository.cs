using Domain.Models;

namespace Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll();
    }
}
