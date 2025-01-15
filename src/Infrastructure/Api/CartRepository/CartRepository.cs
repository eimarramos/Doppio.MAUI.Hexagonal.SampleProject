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
        public async Task AddCoffeeToCart(int coffeeId)
        {
            CartEntity cart = await _context.Carts.AsNoTracking()
                                                   .Include(c => c.CartDetails)
                                                   .FirstAsync();

            CartDetailEntity? detail = cart.CartDetails.FirstOrDefault(cd => cd.Id == coffeeId);

            if (detail == null)
            {
                CoffeeEntity? coffee = await _context.Coffees.AsNoTracking()
                                                            .FirstOrDefaultAsync(c => c.Id == coffeeId);

                if (coffee == null)
                {
                    throw new Exception("Coffee not found");
                }

                CartDetailEntity newDetail = new CartDetailEntity
                {
                    Coffee = coffee,
                    Quantity = 1
                };
                cart.CartDetails.Add(newDetail);
            }
            else
            {
                detail.Quantity++;
            }
            await _context.SaveChangesAsync();
        }
        public Task RemoveCoffeeFromCart(int coffeeId)
        {
            throw new NotImplementedException();
        }
    }
}
