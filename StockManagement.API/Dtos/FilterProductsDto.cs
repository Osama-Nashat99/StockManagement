namespace StockManagement.API.Dtos
{
    public class FilterProductsDto
    {
        public int PageSize { get; set; }

        public int PageNumber { get; set; }

        public string SearchFilter { get; set; } = string.Empty;

        public string SortBy {  get; set; } = string.Empty;

        public string SortDirection {  get; set; } = string.Empty;
    }
}
