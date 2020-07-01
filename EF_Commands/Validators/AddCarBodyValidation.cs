using Application.Dto;
using EF_DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_Commands.Validators
{
    public class AddCarBodyValidation : AbstractValidator<CarBodyDto>
    {
        public AddCarBodyValidation(asp_projectContext context)
        {
            RuleFor(c => c.Name)
                .Matches(@"^[A-z''-'+\s\d]{2,30}$").WithMessage("Car body name format not allowed.")
                .Must(name => !context.CarBodies.Any(c => c.Name == name)).WithMessage("Car body name must be unique.");
        }
    }
}
