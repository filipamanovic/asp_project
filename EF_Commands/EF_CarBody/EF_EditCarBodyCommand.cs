using Application.Commands.CarBody;
using Application.Dto;
using Application.Exceptions;
using EF_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_Commands.EF_CarBody
{
    public class EF_EditCarBodyCommand : EF_BaseEntity, IEditCarBodyCommand
    {
        public EF_EditCarBodyCommand(asp_projectContext context) : base(context) { }

        public int Id => 14;
        public string UseCaseName => "EditCarBodyUsingEF";
        public void Execute(CarBodyDto request)
        {
            var carbody = Context.CarBodies.Find(request.Id);
            if (carbody == null)
            {
                throw new EntityNotFoundException();
            }
            if (carbody.IsDeleted == true)
            {
                throw new EntityAlreadyDeletedException();
            }
            if (carbody.Name != request.Name)
            {
                if (Context.CarBodies.Any(f => f.Name == request.Name))
                {
                    throw new EntityAlreadyExistException();
                }
            }
            carbody.Name = request.Name;
            Context.SaveChanges();
        }
    }
}
