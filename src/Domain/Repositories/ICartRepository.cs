using Domain.Models;

namespace Domain.Repositories
{
    public interface ICartRepository
    {
        Task<List<CartDetail>> GetCartDetails();
        Task<int> GetCurrentItemsCount();
        Task<decimal> GetTotal();
        Task AddCoffeeToCart(int coffeeId);
        Task RemoveCoffeeFromCart(int coffeeId);
    }
}
