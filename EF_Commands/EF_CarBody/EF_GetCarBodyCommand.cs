using Application.Commands.CarBody;
using Application.Dto;
using Application.Exceptions;
using EF_DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Commands.EF_CarBody
{
    public class EF_GetCarBodyCommand : EF_BaseEntity, IGetCarBodyCommand
    {
        public EF_GetCarBodyCommand(asp_projectContext context) : base(context) { }

        public CarBodyDto Execute(int request)
        {
            var carbody = Context.CarBodies.Find(request);
            if (carbody == null)
            {
                throw new EntityNotFoundException();
            }
            if (carbody.IsDeleted)
                throw new EntityAlreadyDeletedException();
            return new CarBodyDto
            {
                Id = carbody.Id,
                Name = carbody.Name
            };
        }
    }
}
