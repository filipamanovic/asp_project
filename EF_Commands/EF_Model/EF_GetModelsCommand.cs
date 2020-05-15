using Application.Commands.Model;
using Application.Dto;
using Application.Searches;
using EF_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_Commands.EF_Model
{
    public class EF_GetModelsCommand : EF_BaseEntity, IGetModelsCommand
    {
        public EF_GetModelsCommand(asp_projectContext context) : base(context)
        {
        }

        public IEnumerable<ModelDto> Execute(ModelSearch request)
        {
            var query = Context.Models.AsQueryable();

            if (request.Keyword != null)
                query = query.Where(m => m.Name.ToLower().Contains(request.Keyword.ToLower()));           
            if (request.IsActive.HasValue)           
                query = query.Where(m => m.IsDeleted != request.IsActive);
            if (request.BrandId != null)
                query = query.Where(m => m.BrandId == request.BrandId);

            return query.Where(m => !m.IsDeleted).Select(m => new ModelDto
            {
                Id = m.Id,
                Name = m.Name,
                BrandName = m.Brand.Name
            });

        }
    }
}
