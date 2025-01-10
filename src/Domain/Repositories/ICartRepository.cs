using Domain.Models;

namespace Domain.Repositories
{
    public interface ICartRepository
    {
        Task<List<Coffee>> GetCoffesInCart();
        Task AddCoffeeToCart(int coffeeId);
        Task RemoveCoffeeFromCart(int coffeeId);
    }
}
