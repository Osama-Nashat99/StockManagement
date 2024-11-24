
using StockManagement.Domain.Entities;
using StockManagement.Domain.Interfaces;
using StockManagement.Domain.Validators;
using System.Net;

namespace StockManagement.Domain.Services
{
    public class CategoryService
    {
        private ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Result<IEnumerable<Category>> Get()
        {
            IEnumerable<Category> categories = _categoryRepository.Get().Result;

            if (categories == null) {
                return Result<IEnumerable<Category>>.Failure("No category were found", HttpStatusCode.NotFound);
            }

            return Result<IEnumerable<Category>>.Success(categories);
        }
    }
}
