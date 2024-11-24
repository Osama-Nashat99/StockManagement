using StockManagement.Domain.Entities;

namespace StockManagement.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> Get();
    }
}
