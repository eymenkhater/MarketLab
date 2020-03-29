namespace MarketLab.Application.Core.Models
{
    public class ResponseBase<T>
    {
        public ResponseBase(T data)
        {
            this.Code = 200;
            this.Message = "OK";
            this.Success = true;
            this.Data = data;
        }
        public ResponseBase(int code, bool success, string message, T data, string exception, object errors)
        {
            Code = code;
            Success = success;
            Message = message;
            Data = data;
            this.exception = exception;
            Errors = errors;
        }

        public int Code { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public string exception { get; set; }
        public object Errors { get; set; }
    }
}