using Application.Commands.Fuel;
using Application.Dto;
using Application.Exceptions;
using EF_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_Commands.EF_Fuel
{
    public class EF_EditFuelCommand : EF_BaseEntity, IEditFuelCommand
    {
        public EF_EditFuelCommand(asp_projectContext context) : base(context) { }
        public void Execute(FuelDto request)
        {
            var fuel = Context.Fuels.Find(request.Id);
            if(fuel == null)
            {
                throw new EntityNotFoundException();
            }
            if(fuel.IsDeleted == true)
            {
                throw new EntityAlreadyDeletedException();
            }
            if(fuel.Name != request.Name)
            {
                if (Context.Fuels.Any(f => f.Name == request.Name))
                {
                    throw new EntityAlreadyExistException();
                }
            }
            fuel.Name = request.Name;
            fuel.ModifiedAt = DateTime.Now;
            Context.SaveChanges();
        }
    }
}
