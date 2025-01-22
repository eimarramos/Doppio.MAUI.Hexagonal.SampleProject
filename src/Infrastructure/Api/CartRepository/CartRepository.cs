using AutoMapper;
using Domain.Models;
using Domain.Repositories;
using Infrastructure.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Api.CartRepository
{
    public class CartRepository : ICartRepository
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public CartRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CartDetail>> GetCoffes()
        {
            CartEntity cart = await _context.Carts.AsNoTracking()
                                                  .Include(c => c.CartDetails)
                                                  .FirstAsync();

            List<CartDetail> cartDetailsMapped = _mapper.Map<List<CartDetail>>(cart.CartDetails);

            return cartDetailsMapped;
        }

        public async Task<int> GetCurrentItemsCount()
        {
            CartEntity cart = await _context.Carts.AsNoTracking()
                                                  .Include(c => c.CartDetails)
                                                  .FirstAsync();
            return cart.CartDetails.Sum(cd => cd.Quantity);
        }

        public async Task<decimal> GetTotal()
        {
            CartEntity cart = await _context.Carts.AsNoTracking()
                                                  .Include(c => c.CartDetails)
                                                  .FirstAsync();
            return cart.Total;
        }

        public async Task AddCoffeeToCart(int coffeeId)
        {
            var cart = await _context.Carts
                                     .Include(c => c.CartDetails)
                                     .FirstAsync();

            var detail = cart.CartDetails.FirstOrDefault(cd => cd.Id == coffeeId);

            if (detail != null)
            {
                detail.Quantity++;
            }
            else
            {
                var coffee = await _context.Coffees.FindAsync(coffeeId);
                if (coffee == null)
                {
                    throw new Exception("Coffee not found");
                }

                var newDetail = new CartDetailEntity
                {
                    Cart = cart,
                    Coffee = coffee,
                    Quantity = 1
                };

                cart.CartDetails.Add(newDetail);
            }

            await _context.SaveChangesAsync();
        }

        public async Task RemoveCoffeeFromCart(int coffeeId)
        {
            CartEntity cart = await _context.Carts.AsNoTracking()
                                                  .Include(c => c.CartDetails)
                                                  .FirstAsync();

            if (cart.CartDetails.Any(d => d.Coffee?.Id == coffeeId))
            {
                CartDetailEntity detail = cart.CartDetails.First(cd => cd.Coffee?.Id == coffeeId);
                if (detail.Quantity > 1)
                {
                    detail.Quantity--;
                }
                else
                {
                    cart.CartDetails.Remove(detail);
                }
                await _context.SaveChangesAsync();
            }
        }
    }
}
