using System.Collections.Generic;
namespace Data_Access.Communication
{
    public static class Response 
    {
        public static Response<T> Fail<T>(string message) =>
            new Response<T>(false, message);
   

        public static Response<T> Ok<T>(T data, string message) =>
            new Response<T>(true, message, data);

        public static Response<T> Ok<T>(IEnumerable<T> data, string message) =>
            new Response<T>(true, message, data);
 
    }
    public class Response<T>
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }
        public T Data { get; protected set; }
        public IEnumerable<T> ListData { get; protected set; }
       

        public Response(bool success, string message, T data)
        {
            this.Success = success;
            this.Message = message ?? string.Empty;
            this.Data = data;
        }
        public Response(bool success, string message, IEnumerable<T> listData)
        {
            this.Success = success;
            this.Message = message ?? string.Empty;
            this.ListData = listData;
        }
    
        public Response(string message) : this(false, message, default(T))
        {
        }

  
        public Response(T data) : this(true, string.Empty, data)
        {
        }

        public Response(bool v, string message)
        {
            Success = v;
            Message = message;
        }
    }
}
