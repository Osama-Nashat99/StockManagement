using StockManagement.Domain.Entities;

namespace StockManagement.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Get(string username, string password);
    }
}
