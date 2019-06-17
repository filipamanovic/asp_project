using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class BrandSearch
    {
        public string NameKeyword { get; set; }
        public string StateKeyWord { get; set; }
        public string CityKeyWord { get; set; }
        public bool? IsActive { get; set; }
    }
}
