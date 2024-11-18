using StockManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
