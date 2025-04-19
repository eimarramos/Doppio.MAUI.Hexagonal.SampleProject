using Domain.Models;
using Domain.Repositories;

namespace ApplicationLayer.Services.CartService
{
    public class CartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<List<CartDetail>> GetCartDetails()
        {
            return await _cartRepository.GetCartDetails();
        }

        public async Task<int> GetCurrentItemsCount()
        {
            return await _cartRepository.GetCurrentItemsCount();
        }

        public async Task<decimal> GetTotal()
        {
            return await _cartRepository.GetTotal();
        }

        public async Task AddCoffeeToCart(int coffeeId)
        {
            await _cartRepository.AddCoffeeToCart(coffeeId);
        }

        public async Task RemoveCoffeeFromCart(int coffeeId)
        {
            await _cartRepository.RemoveCoffeeFromCart(coffeeId);
        }

        public async Task RemoveTypeOfCoffeeFromCart(int coffeeId)
        {
            await _cartRepository.RemoveTypeOfCoffeeFromCart(coffeeId);
        }
    }
}
