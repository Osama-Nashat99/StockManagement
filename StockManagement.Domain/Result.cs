using System.Net;

namespace StockManagement.Domain
{
    public class Result<T>
    {
        private Result(bool isSuccess, HttpStatusCode code, T value, string message)
        {
            this.isSuccess = isSuccess;
            this.code = code;
            this.value = value;
            this.message = message;
        }

        public bool isSuccess {  get; set; }
        public HttpStatusCode code { get; set; }
        public T value { get; set; }
        public string message { get; set; }

        public static Result<T> Success(T value) => new Result<T>(true,HttpStatusCode.OK, value, "");

        public static Result<T> Failure(string message, HttpStatusCode code) => new Result<T>(false, code, default, message);
    }
}
