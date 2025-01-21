using AutoMapper;
using Domain.Models;
using Domain.Repositories;
using Infrastructure.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Api.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Category>> GetAll()
        {
            List<CategoryEntity> categories = await _context.Categories
                                                            .AsNoTracking()
                                                            .ToListAsync();

            List<Category> categoriesMapped = _mapper.Map<List<Category>>(categories);

            return categoriesMapped;
        }
    }
}
