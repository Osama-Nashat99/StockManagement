using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Domain
{
    public class Result<T>
    {
        private Result(bool isSuccess, T value, string message)
        {
            this.isSuccess = isSuccess;
            this.value = value;
            this.message = message;
        }

        public bool isSuccess {  get; set; }
        public T value { get; set; }
        public string message { get; set; }

        public static Result<T> Success(T value) => new Result<T>(true, value, "");

        public static Result<T> Failure(string message) => new Result<T>(false, default, message);
    }
}
