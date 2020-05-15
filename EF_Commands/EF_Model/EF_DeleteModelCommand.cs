using Application.Commands.Model;
using Application.Exceptions;
using EF_DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Commands.EF_Model
{
    public class EF_DeleteModelCommand : EF_BaseEntity, IDeleteModelCommand
    {
        public EF_DeleteModelCommand(asp_projectContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var model = Context.Models.Find(request);
            if (model == null)
                throw new EntityNotFoundException();
            if (model.IsDeleted == true)
                throw new EntityAlreadyDeletedException();

            model.IsDeleted = true;
            model.DeletedAt = DateTime.Now;
            Context.SaveChanges();
        }
    }
}
