using Application.Dto.UserDtoData;
using EF_DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_Commands.Validators
{
    public class EditUserValidator : AbstractValidator<UserDto>
    {
        public EditUserValidator(asp_projectContext context)
        {
            RuleFor(u => u.FirstName)
                .Matches(@"^[A-Z][a-z]{2,30}$").WithMessage("First name format not allowed, first letter capital, max 30caracteers");

            RuleFor(u => u.LastName)
                .Matches(@"^[A-Z][a-z]{2,30}$").WithMessage("Last name format not allowed, first letter capital, max 30caracteers");

            RuleFor(u => u.Email)
                .EmailAddress()
                .Must((dto, email) => !context.Users.Any(u => u.Email == email && u.Id != dto.Id)).WithMessage("Email must be unique");
        }
    }
}
