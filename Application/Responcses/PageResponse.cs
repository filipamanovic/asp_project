using Application.Dto.AdvertisementDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Responcses
{
    public class PageResponse<T>
    {
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<AdvertisementDto> Advertisements { get; set; }
    }
}
