namespace StockManagement.Domain.Interfaces
{
    public interface IEntity
    {
        int Id { get; set; }

        DateTime? CreatedDate { get; set; }

        string CreatedBy { get; set; }

        DateTime? ModifiedDate { get; set; }

        string ModifiedBy { get; set; }
    }
}
