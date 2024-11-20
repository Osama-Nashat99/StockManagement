using StockManagement.Domain.Entities;

namespace StockManagement.Domain.Models
{
    public class FetchProductsModel
    {
        public FetchProductsModel()
        {
            this.Products = new List<Product>();
        }

        public int TotalProducts { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
