using Domain.Models;

namespace Domain.Repositories
{
    public interface ICartRepository
    {
        Task<List<Coffee>> GetCoffesInCart(int userId);
        Task AddCoffeeToCart(int userId, int coffeeId);
        Task RemoveCoffeeFromCart(int userId, int coffeeId);
    }
}
