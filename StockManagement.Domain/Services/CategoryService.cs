
using StockManagement.Domain.Entities;
using StockManagement.Domain.Exceptions;
using StockManagement.Domain.Interfaces;
using StockManagement.Domain.Models;

namespace StockManagement.Domain.Services
{
    public class CategoryService
    {
        private ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<Category> Get()
        {
            IEnumerable<Category> categories = _categoryRepository.Get().Result;

            if (categories == null)
                throw new NotFoundException("No category were found");

            return categories;
        }

        public FetchModel<Category> FetchCategories(int pageNumber = 1, int pageSize = 10, string searchFilter = "", string sortBy = "id", string sortDirection = "asc")
        {
            FetchModel<Category> categoriesModel = _categoryRepository.FetchAsync(pageNumber, pageSize, searchFilter, sortBy, sortDirection).Result;

            if (categoriesModel == null)
                throw new Exception("Could not fetch categories");

            return categoriesModel;
        }

        public Category AddCategory(Category category)
        {
            if (string.IsNullOrEmpty(category.Name))
                throw new Exception("Category name is required");

            category = _categoryRepository.Create(category).Result;

            if (category == null || category.Id <= 0)
                throw new Exception("Category was not added");

            return category;
        }
    }
}
