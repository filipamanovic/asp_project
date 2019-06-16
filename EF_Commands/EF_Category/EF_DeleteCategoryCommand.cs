using Application.Commands.Category;
using Application.Exceptions;
using EF_DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Commands.EF_Category
{
    public class EF_DeleteCategoryCommand : EF_BaseEntity, IDeleteCategoryCommand
    {
        public EF_DeleteCategoryCommand(asp_projectContext context) : base(context) { }
        public void Execute(int request)
        {
            var category = Context.Categories.Find(request);
            if(category == null)
            {
                throw new EntityNotFoundException();
            }
            if(category.IsDeleted == true)
            {
                throw new EntityAlreadyDeletedException();
            }
            category.IsDeleted = true;
            Context.SaveChanges();
        }
    }
}
