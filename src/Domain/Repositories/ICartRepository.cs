using Domain.Models;

namespace Domain.Repositories
{
    public interface ICartRepository
    {
        Task<List<CartDetail>> GetCoffes();
        Task AddCoffeeToCart(int coffeeId);
        Task RemoveCoffeeFromCart(int coffeeId);
    }
}
