using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public abstract class PagedSearch
    {
        public int CurrentPage { get; set; } = 1;
        public int PerPage { get; set; } = 5;
    }
}
