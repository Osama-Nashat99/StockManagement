namespace StockManagement.API.Dtos
{
    public class FetchProductsDto
    {
        public FetchProductsDto()
        {
            this.Products = new List<ProductDto>();
        }

        public int TotalProducts { get; set; }

        public IEnumerable<ProductDto> Products { get; set; }
    }
}
