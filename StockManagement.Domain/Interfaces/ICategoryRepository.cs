using StockManagement.Domain.Entities;
using StockManagement.Domain.Models;

namespace StockManagement.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> Get();

        Task<FetchModel<Category>> FetchAsync(int pageNumber = 1, int pageSize = 10, string searchFilter = "", string sortBy = "id", string sortDirection = "asc");

        Task<Category> Create(Category category);
    }
}
