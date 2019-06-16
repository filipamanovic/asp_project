using Application.Commands.Category;
using Application.Dto;
using Application.Searches;
using EF_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_Commands.EF_Category
{
    public class EF_GetCategoriesCommand : EF_BaseEntity, IGetCategoriesCommand
    {
        public EF_GetCategoriesCommand(asp_projectContext context) : base(context) { }
        public IEnumerable<CategoryDto> Execute(CategorySearch request)
        {
            var query = Context.Categories.AsQueryable();
            if(request.Keyword != null)
            {
                query = query.Where(c => c.Name.ToLower().Contains(request.Keyword.ToLower()));
            }
            if (request.IsActive.HasValue)
            {
                query = query.Where(c => c.IsDeleted != request.IsActive);
            }
            return query.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name
            });
        }
    }
}
