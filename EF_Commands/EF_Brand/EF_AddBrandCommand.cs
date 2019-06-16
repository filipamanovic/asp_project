using Application.Commands.Brand;
using Application.Dto;
using Application.Exceptions;
using Domain;
using EF_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_Commands.EF_Brand
{
    public class EF_AddBrandCommand : EF_BaseEntity, IAddBrandCommand
    {
        public EF_AddBrandCommand(asp_projectContext context) : base(context) { }
        public void Execute(BrandDto request)
        {
            if (Context.Brands.Any(b => b.Name == request.Name))
            {
                throw new EntityAlreadyExistException();
            }
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
