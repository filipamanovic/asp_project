using Application.Commands.Brand;
using Application.Dto;
using Application.Exceptions;
using Application.Interfaces;
using Domain;
using EF_Commands.Validators;
using EF_DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_Commands.EF_Brand
{
    public class EF_AddBrandCommand : EF_BaseEntity, IAddBrandCommand
    {
        private readonly AddBrandValidator _addBrandValidator;
        public EF_AddBrandCommand(asp_projectContext context, AddBrandValidator validationRules) : base(context) 
        {
            _addBrandValidator = validationRules;
        }

        public int Id => 1;
        public string UseCaseName => "CreateNewBrandUsingEF"; 

        public void Execute(BrandDto request)
        {
            _addBrandValidator.ValidateAndThrow(request);

            Context.Brands.Add(new Brand
            {
                Name = request.Name,
                City = request.City,
                State = request.State,
                Logo = request.LogoUrl
            });
            Context.SaveChanges();
        }
    }
}
