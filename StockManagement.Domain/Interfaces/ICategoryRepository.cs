using StockManagement.Domain.Entities;
using StockManagement.Domain.Models;

namespace StockManagement.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<Category> GetById(int id);

        public Task<IEnumerable<Category>> GetAll();

        Task<FetchModel<Category>> FetchAsync(int pageNumber = 1, int pageSize = 10, string searchFilter = "", string sortBy = "id", string sortDirection = "asc");

        Task<Category> AddAsync(Category category);

        void Delete(Category category);
    }
}
