using Application.Commands.Brand;
using Application.Dto;
using Application.Exceptions;
using EF_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_Commands.EF_Brand
{
    public class EF_EditBrandCommand : EF_BaseEntity, IEditBrandCommand
    {
        public EF_EditBrandCommand(asp_projectContext context) : base(context)
        {
        }

        public int Id => 4;
        public string UseCaseName => "EditBrandUsingEF";

        public void Execute(BrandDto request)
        {
            var brand = Context.Brands.Find(request.Id);
            if (brand == null)
            {
                throw new EntityNotFoundException();
            }
            if (brand.IsDeleted == true)
            {
                throw new EntityAlreadyDeletedException();
            }
            if (brand.Name != request.Name && request.Name != null)
            {
                if (Context.Brands.Any(f => f.Name == request.Name))
                {
                    throw new EntityAlreadyExistException();
                }
            }
            if(request.Name != null)
            {
                brand.Name = request.Name;
            }
            if (request.State != null)
            {
                brand.State = request.State;
            }
            if (request.City != null)
            {
                brand.City = request.City;
            }
            if (request.LogoUrl != null)
            {
                brand.Logo = request.LogoUrl;
            }
            Context.SaveChanges();
        }
    }
}
