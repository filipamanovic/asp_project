using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Responses
{
    public class PageResponse<T>
    {
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
