using Domain.Models;
using Domain.Repositories;

namespace ApplicationLayer.Services.CategoryService
{
    public class CategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> GetAll()
        {
            return await _categoryRepository.GetAll();
        }
    }
}
