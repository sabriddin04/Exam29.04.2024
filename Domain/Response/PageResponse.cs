using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Response
{
    public class PageResponse<T>:Response<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecord { get; set; }
        public int TotalPage { get; set; }

        public PageResponse(T data, int pageNumber, int pageSize, int totalRecord):base(data)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalRecord = totalRecord;
            TotalPage=(int)Math.Ceiling(totalRecord/(float)pageSize);
        }

        public PageResponse(HttpStatusCode statusCode, string error) : base(statusCode, error)
        {
        }

        public PageResponse(HttpStatusCode statusCode, List<string> error) : base(statusCode, error)
        {
        }
    }
}
