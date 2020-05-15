using Application.Commands.Brand;
using Application.Dto;
using Application.Searches;
using EF_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_Commands.EF_Brand
{
    public class EF_GetBrandsCommand : EF_BaseEntity, IGetBrandsCommand
    {
        public EF_GetBrandsCommand(asp_projectContext context) : base(context)
        {
        }

        public IEnumerable<BrandDto> Execute(BrandSearch request)
        {
            var query = Context.Brands.AsQueryable();

            if(request.NameKeyword != null)
            {
                query = query.Where(b => b.Name.ToLower().Contains(request.NameKeyword.ToLower()));
            }

            if (request.CityKeyWord != null)
            {
                query = query.Where(b => b.City.ToLower().Contains(request.CityKeyWord.ToLower()));
            }

            if (request.StateKeyWord != null)
            {
                query = query.Where(b => b.State.ToLower().Contains(request.StateKeyWord.ToLower()));
            }

            if (request.IsActive.HasValue)
            {
                query = query.Where(b => b.IsDeleted != request.IsActive);
            }

            return query.Where(b => !b.IsDeleted).Select(b => new BrandDto
            {
                Id = b.Id,
                Name = b.Name,
                State = b.State,
                City = b.City,
                LogoUrl = b.Logo
            });
            
        }
    }
}
