namespace StockManagement.Domain.Models
{
    public class LoginResponseModel
    {
        public string Token { get; set; }

        public bool IsFirstLogin { get; set; }

        public string FullName { get; set; }

        public string userId { get; set; }
    }
}
