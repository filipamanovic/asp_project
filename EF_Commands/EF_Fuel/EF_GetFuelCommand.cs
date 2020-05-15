using Application.Commands.Fuel;
using Application.Dto;
using Application.Exceptions;
using EF_DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Commands.EF_Fuel
{
    public class EF_GetFuelCommand : EF_BaseEntity, IGetFuelCommand
    {
        public EF_GetFuelCommand(asp_projectContext context) : base(context) { }
        public FuelDto Execute(int request)
        {
            var fuel = Context.Fuels.Find(request);
            if(fuel == null)
            {
                throw new EntityNotFoundException();
            }
            if (fuel.IsDeleted)
                throw new EntityAlreadyDeletedException();
            return new FuelDto
            {
                Id = fuel.Id,
                Name = fuel.Name
            };
        }
    }
}
