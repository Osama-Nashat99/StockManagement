using Microsoft.EntityFrameworkCore;
using StockManagement.Domain.Entities;
using StockManagement.Domain.Interfaces;

namespace StockManagement.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            _db = applicationDbContext;
        }

        public async Task<User> Get(string username, string password)
        {
            return await _db.users.AsNoTracking().FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        }
    }
}
