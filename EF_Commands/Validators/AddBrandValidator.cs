using Application.Dto;
using EF_DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_Commands.Validators
{
    public class AddBrandValidator : AbstractValidator<BrandDto>
    {
        public AddBrandValidator(asp_projectContext context)
        {
            RuleFor(b => b.Name)
                .Must(name => !context.Brands.Any(b => b.Name == name)).WithMessage("Brand name must be unique.")
                .Matches(@"^[A-z''-'+\s\d]{2,30}$").WithMessage("Brand name format not allowed");

            RuleFor(b => b.City)
                .Matches(@"^[A-z\s]{2,30}$").WithMessage("Brand city format is not allowed.");

            RuleFor(b => b.State)
                .Matches(@"^[A-z\s]{2,30}$").WithMessage("Brand state format is not allowed.");
        }
    }
}
