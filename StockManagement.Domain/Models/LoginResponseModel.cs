using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Domain.Models
{
    public class LoginResponseModel
    {
        public string Token { get; set; }

        public bool IsFirstLogin { get; set; }
    }
}
