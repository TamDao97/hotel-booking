using Microsoft.AspNetCore.Http;

namespace WebHotel.DTO
{
    public class ResponseApi<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }

        public static ResponseApi<T> Success(T data)
        {
            return new ResponseApi<T>
            {
                StatusCode = 200,
                Message = "Successfully!",
                Data = data
            };
        }

        public static ResponseApi<T> Error(int statusCode, string message)
        {
            return new ResponseApi<T>
            {
                StatusCode = statusCode,
                Message = message,
            };
        }
    }

    public class GridReponseApi<T>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalData { get; set; }
        public List<T>? GridData { get; set; }
    }
}
