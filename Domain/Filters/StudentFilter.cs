using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Filters
{
    public class StudentFilter:PaginationFilter
    {       
        public string? Email { get; set; }
    }
}