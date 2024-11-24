namespace StockManagement.API.Dtos
{
    public class FilterDto
    {
        public int PageSize { get; set; }

        public int PageNumber { get; set; }

        public string Search { get; set; } = string.Empty;

        public string SortBy {  get; set; } = string.Empty;

        public string SortDirection {  get; set; } = string.Empty;
    }
}
