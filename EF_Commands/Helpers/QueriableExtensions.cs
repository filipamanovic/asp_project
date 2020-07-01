using Application.Responcses;
using Application.Searches;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_Commands.Helpers
{
    public static class QueriableExtensions
    {
        public static PageResponse<TDto> Paged<TDto, TEntity>(this IQueryable<TEntity> query,
            PagedSearch search, IMapper mapper) where TDto : class
        {
            var skipCount = search.PerPage * (search.CurrentPage - 1);
      
            var response = new PageResponse<TDto>
            {
                CurrentPage = search.CurrentPage,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                PageCount = (int)Math.Ceiling((double)query.Count() / search.PerPage),
                Data = mapper.Map<IEnumerable<TDto>>(query.Skip(skipCount).Take(search.PerPage))
            };

            return response;
        }
    }
}
