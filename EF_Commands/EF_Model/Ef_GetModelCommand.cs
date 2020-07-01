using Application.Commands.Model;
using Application.Dto;
using Application.Exceptions;
using EF_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_Commands.EF_Model
{
    public class Ef_GetModelCommand : EF_BaseEntity, IGetModelCommand
    {
        public Ef_GetModelCommand(asp_projectContext context) : base(context)
        {
        }

        public int Id => 8;
        public string UseCaseName => "GetModelUsingEF";

        public ModelDto Execute(int request)
        {
            var model = Context.Models.Find(request);
            if (model == null)
                throw new EntityNotFoundException();
            if (model.IsDeleted)
                throw new EntityAlreadyDeletedException();

            var query = Context.Models.AsQueryable();
            return query.Where(m => m.Id == request && !m.IsDeleted).Select(m => new ModelDto
            {
                Id = m.Id,
                Name = m.Name,
                BrandName = m.Brand.Name
            }).FirstOrDefault();            
        }
    }
}
