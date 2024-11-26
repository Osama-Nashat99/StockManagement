using StockManagement.Domain.Entities;
using StockManagement.Domain.Models;

namespace StockManagement.Domain.Interfaces
{
    public interface IStoreRepository
    {
        public Task<bool> IsStoreExistsAsync(int id);

        public Task<Store> GetByIdAsync(int id);

        public Task<IEnumerable<Store>> GetAll();

        Task<FetchModel<Store>> FetchAsync(int pageNumber = 1, int pageSize = 10, string searchFilter = "", string sortBy = "id", string sortDirection = "asc");

        Task<Store> AddAsync(Store store);

        Store Update(Store store);

        void Delete(Store store);
    }
}
