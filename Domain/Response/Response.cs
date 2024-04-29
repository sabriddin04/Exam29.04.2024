using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Domain.Response
{
    public class Response<T>
    {
        
        public int StatusCode { get; set; }
        public List<string> Description { get; set; } = new List<string>();
        public T? Data { get; set; }

        public Response(HttpStatusCode statusCode, string message, T data)
        {
            StatusCode = (int)statusCode;
            Description.Add(message);
            Data = data;
        }

        public Response(HttpStatusCode statusCode, List<string> message, T data)
        {
            StatusCode = (int)statusCode;
            Description = message;
            Data = data;
        }
        public Response(HttpStatusCode statusCode, string message)
        {
            StatusCode = (int)statusCode;
            Description.Add(message);
        }
        public Response(HttpStatusCode statusCode, List<string> message)
        {
            StatusCode = (int)statusCode;
            Description = message;
        }

        public Response(T data)
        {
            StatusCode = 200;
            Data = data;
        }

        
    }
}
