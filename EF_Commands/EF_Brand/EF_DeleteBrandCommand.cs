using Application.Commands.Brand;
using Application.Exceptions;
using EF_DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Commands.EF_Brand
{
    public class EF_DeleteBrandCommand : EF_BaseEntity, IDeleteBrandCommand
    {
        public EF_DeleteBrandCommand(asp_projectContext context) : base(context)
        {
        }

        public int Id => 5;
        public string UseCaseName => "DeleteBrandUsingEF";

        public void Execute(int request)
        {
            var brand = Context.Brands.Find(request);
            if (brand == null)
            {
                throw new EntityNotFoundException();
            }
            if (brand.IsDeleted == true)
            {
                throw new EntityAlreadyDeletedException();
            }
            brand.IsDeleted = true;
            brand.DeletedAt = DateTime.Now;
            Context.SaveChanges();
        }
    }
}
