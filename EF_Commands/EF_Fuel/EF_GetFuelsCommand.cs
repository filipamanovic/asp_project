using Application.Commands.Fuel;
using Application.Dto;
using Application.Interfaces;
using Application.Searches;
using EF_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_Commands.EF_Fuel
{
    public class EF_GetFuelsCommand : EF_BaseEntity, IGetFuelsCommand
    {
        public EF_GetFuelsCommand(asp_projectContext context) : base(context) { }

        public int Id => 22;
        public string UseCaseName => "GetFuelsUsingEF";

        public IEnumerable<FuelDto> Execute(FuelSearch request)
        {
            var query = Context.Fuels.AsQueryable();
            if (request.Keyword != null)
            {
                query = query.Where(f => f.Name.ToLower().Contains(request.Keyword.ToLower()));
            }
            if (request.IsActive.HasValue)
            {
                query = query.Where(f => f.IsDeleted != request.IsActive);
            }
            return query.Select(f => new FuelDto
            {
                Id = f.Id,
                Name = f.Name
            });
        }
    }
}
