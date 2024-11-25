using Microsoft.AspNetCore.Mvc;

namespace StockManagement.API
{
    public class CustomProblemDetails : ProblemDetails
    {
        public string ExceptionMessage { get; set; }
    }
}
