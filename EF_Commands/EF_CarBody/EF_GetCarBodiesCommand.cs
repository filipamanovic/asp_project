using Application.Commands.CarBody;
using Application.Dto;
using Application.Searches;
using EF_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_Commands.EF_CarBody
{
    public class EF_GetCarBodiesCommand : EF_BaseEntity, IGetCarBodiesCommand
    {
        public EF_GetCarBodiesCommand(asp_projectContext context) : base(context) { }

        public int Id => 12;
        public string UseCaseName => "GetCarBodiesUsingEF";

        public IEnumerable<CarBodyDto> Execute(CarBodySearch request)
        {
            var query = Context.CarBodies.AsQueryable();
            if(request.Keyword != null)
            {
                query = query.Where(c => c.Name.ToLower().Contains(request.Keyword.ToLower()));
            }
            if (request.IsActive.HasValue)
            {
                query = query.Where(c => c.IsDeleted != request.IsActive);
            }
            return query.Where(c => !c.IsDeleted).Select(c => new CarBodyDto
            {
                Id = c.Id,
                Name = c.Name
            });
        }
    }
}
