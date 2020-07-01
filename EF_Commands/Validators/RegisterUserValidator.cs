using Application.Dto.UserDtoData;
using EF_DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_Commands.Validators
{
    public class RegisterUserValidator : AbstractValidator<UserDto>
    {
        public RegisterUserValidator(asp_projectContext context)
        {
            RuleFor(u => u.FirstName)
                .NotEmpty()
                .Matches(@"^[A-Z][a-z]{2,30}$").WithMessage("First name format not allowed, first letter capital, max 30caracteers");

            RuleFor(u => u.LastName)
                .Matches(@"^[A-Z][a-z]{2,30}$").WithMessage("Last name format not allowed, first letter capital, max 30caracteers");

            RuleFor(u => u.PhoneNumber)
                .NotEmpty();

            RuleFor(u => u.Password)
                .NotEmpty()
                .MinimumLength(6);

            RuleFor(u => u.Email)
                .NotEmpty()
                .EmailAddress()
                .Must(email => !context.Users.Any(u => u.Email == email)).WithMessage("Email must be unique");
        }
    }
}
