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
    public class EF_EditModelCommand : EF_BaseEntity, IEditModelCommand
    {
        public EF_EditModelCommand(asp_projectContext context) : base(context)
        {
        }

        public int Id => 9;
        public string UseCaseName => "EditModelUsingEF";

        public void Execute(ModelDto request)
        {
            var model = Context.Models.Find(request.Id);
            if (model == null)
                throw new EntityNotFoundException();
            if (model.IsDeleted)
                throw new EntityAlreadyDeletedException();
            if(model.Name != request.Name)           
                if (Context.Models.Any(m => m.Name == request.Name))
                    throw new EntityAlreadyExistException();

            if (request.Name != null)
                model.Name = request.Name;

            Context.SaveChanges();
        }
    }
}
