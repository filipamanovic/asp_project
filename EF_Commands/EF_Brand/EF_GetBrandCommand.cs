﻿using Application.Commands.Brand;
using Application.Dto;
using Application.Exceptions;
using EF_DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Commands.EF_Brand
{
    public class EF_GetBrandCommand : EF_BaseEntity, IGetBrandCommand
    {
        public EF_GetBrandCommand(asp_projectContext context) : base(context)
        {
        }

        public int Id => 3;
        public string UseCaseName => "GetBrandUsingEF";

        public BrandDto Execute(int request)
        {
            var brand = Context.Brands.Find(request);
            if (brand == null)
            {
                throw new EntityNotFoundException();
            }
            if (brand.IsDeleted == true)
                throw new EntityAlreadyDeletedException();

            return new BrandDto
            {
                Id = brand.Id,
                Name = brand.Name,
                City = brand.City,
                LogoUrl = brand.Logo,
                State = brand.State
            };
        }
    }
}
