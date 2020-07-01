using Application.Commands.CarBody;
using Application.Dto;
using Application.Exceptions;
using Domain;
using EF_Commands.Validators;
using EF_DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_Commands.EF_CarBody
{
    public class EF_AddCarBodyCommand : EF_BaseEntity, IAddCarBodyCommand
    {
        private readonly AddCarBodyValidation _addCarBodyValidation;
        public EF_AddCarBodyCommand(asp_projectContext context, AddCarBodyValidation validations) : base(context) 
        {
            _addCarBodyValidation = validations;
        }

        public int Id => 11;
        public string UseCaseName => "CreateCarBodyUsingEF";

        public void Execute(CarBodyDto request)
        {
            _addCarBodyValidation.ValidateAndThrow(request);

            Context.CarBodies.Add(new CarBody
            {
                Id = request.Id,
                Name = request.Name
            });
            Context.SaveChanges();
        }
    }
}
