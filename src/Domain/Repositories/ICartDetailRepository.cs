using Domain.Models;

namespace Domain.Repositories
{
    public interface ICartDetailRepository
    {
        Task<List<Coffee>> GetCoffes();
        Task AddCoffeeToCart(int coffeeId);
        Task RemoveCoffeeFromCart(int coffeeId);
    }
}
