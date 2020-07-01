using Application.Commands.Fuel;
using Application.Exceptions;
using EF_DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Commands.EF_Fuel
{
    public class EF_DeleteFuelCommand : EF_BaseEntity, IDeleteFuelCommand
    {
        public EF_DeleteFuelCommand(asp_projectContext context) : base(context) { }

        public int Id => 25;
        public string UseCaseName => "DeleteFuelUsingEF";

        public void Execute(int request)
        {
            var fuel = Context.Fuels.Find(request);
            if(fuel == null)
            {
                throw new EntityNotFoundException();
            }
            if(fuel.IsDeleted == true)
            {
                throw new EntityAlreadyDeletedException();
            }
            fuel.IsDeleted = true;
            fuel.DeletedAt = DateTime.Now;
            Context.SaveChanges();
        }
    }
}
