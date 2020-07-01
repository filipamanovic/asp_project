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
    public class EF_AddFuelCommand : EF_BaseEntity, IAddFuelCommand
    {
        public EF_AddFuelCommand(asp_projectContext context) : base(context) { }

        public int Id => 21;
        public string UseCaseName => "CreateFuelUsingEF";

        public void Execute(FuelDto request)
        {
            if(Context.Fuels.Any(f => f.Name == request.Name))
            {
                throw new EntityAlreadyExistException();
            }
            Context.Fuels.Add(new Domain.Fuel
            {
                Name = request.Name
            });
            Context.SaveChanges();
        }
    }
}
