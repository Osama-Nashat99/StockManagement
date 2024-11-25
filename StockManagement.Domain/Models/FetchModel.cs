namespace StockManagement.Domain.Models
{
    public class FetchModel<T>
    {
        public FetchModel()
        {
            this.Entities = new List<T>();
        }

        public int TotalEntities { get; set; }

        public IEnumerable<T> Entities { get; set; }
    }
}
