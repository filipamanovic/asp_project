using Application.Commands.CarBody;
using Application.Dto;
using Application.Exceptions;
using Domain;
using EF_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_Commands.EF_CarBody
{
    public class EF_AddCarBodyCommand : EF_BaseEntity, IAddCarBodyCommand
    {
        public EF_AddCarBodyCommand(asp_projectContext context) : base(context) { }
        public void Execute(CarBodyDto request)
        {
            if(Context.CarBodies.Any(c => c.Name == request.Name))
            {
                throw new EntityAlreadyExistException();
            }
            Context.CarBodies.Add(new CarBody
            {
                Id = request.Id,
                Name = request.Name
            });
            Context.SaveChanges();
        }
    }
}
