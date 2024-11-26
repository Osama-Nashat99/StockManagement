using StockManagement.Domain.Entities;
using StockManagement.Domain.Models;

namespace StockManagement.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<FetchModel<User>> FetchAsync(int pageNumber = 1, int pageSize = 10, string searchFilter = "", string sortBy = "id", string sortDirection = "asc");

        Task<User> GetByIdAsync(int id);

        Task<User> GetByUsername(string username);

        Task<User> AddAsync(User user);

        User UpdatePassword(int id, string password);

        public bool VerifyPassword(User user, string enteredPassword);

        void Delete(User user);
    }
}
