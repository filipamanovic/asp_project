using Application.Dto.AdvertisementDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Responcses
{
    public class PageResponse<T> where T : class
    {
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int TotalCount { get; set; }
        public int ItemsPerPage { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
