namespace StockManagement.API.Dtos
{
    public class FetchDto<T>
    {
        public FetchDto()
        {
            this.Entities = new List<T>();
        }

        public int TotalEntities { get; set; }

        public IEnumerable<T> Entities { get; set; }
    }
}
