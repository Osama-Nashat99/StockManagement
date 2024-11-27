namespace StockManagement.API.Dtos
{
    public class AddStoreDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int StoreKeeperId { get; set; }
    }
}
