using Domain.Models;

namespace Domain.Repositories
{
    public interface ICartRepository
    {
        Task<List<CartDetail>> GetCoffes();
        Task<int> GetCurrentItemsCount();
        Task<decimal> GetTotal();
        Task AddCoffeeToCart(int coffeeId);
        Task RemoveCoffeeFromCart(int coffeeId);
    }
}
