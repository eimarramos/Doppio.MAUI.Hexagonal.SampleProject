using Domain.Models;
using Domain.Repositories;

namespace Infrastructure.Api.CartRepository
{
    public class CartRepository : ICartRepository
    {
        public Task AddCoffeeToCart(int coffeeId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Coffee>> GetCoffesInCart()
        {
            throw new NotImplementedException();
        }

        public Task RemoveCoffeeFromCart(int coffeeId)
        {
            throw new NotImplementedException();
        }
    }
}
