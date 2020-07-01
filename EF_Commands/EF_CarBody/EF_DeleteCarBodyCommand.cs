using Application.Commands.CarBody;
using Application.Exceptions;
using EF_DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Commands.EF_CarBody
{
    public class EF_DeleteCarBodyCommand : EF_BaseEntity, IDeleteCarBodyCommand
    {
        public EF_DeleteCarBodyCommand(asp_projectContext context) : base(context) { }

        public int Id => 15;
        public string UseCaseName => "DeleteCarBodyUsingEF";

        public void Execute(int request)
        {
            var carbody = Context.CarBodies.Find(request);
            if (carbody == null)
            {
                throw new EntityNotFoundException();
            }
            if (carbody.IsDeleted == true)
            {
                throw new EntityAlreadyDeletedException();
            }
            carbody.IsDeleted = true;
            carbody.DeletedAt = DateTime.Now;
            Context.SaveChanges();
        }
    }
}
