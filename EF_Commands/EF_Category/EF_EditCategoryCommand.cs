using Application.Commands.Category;
using Application.Dto;
using Application.Exceptions;
using EF_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_Commands.EF_Category
{
    public class EF_EditCategoryCommand : EF_BaseEntity, IEditCategoryCommand
    {
        public EF_EditCategoryCommand(asp_projectContext context) : base(context) { }
        public void Execute(CategoryDto request)
        {
            var category = Context.Categories.Find(request.Id);
            if(category == null)
            {
                throw new EntityNotFoundException();
            }
            if(category.IsDeleted == true)
            {
                throw new EntityAlreadyDeletedException();
            }
            if(category.Name != request.Name)
            {
                if(Context.Categories.Any(c => c.Name == request.Name))
                {
                    throw new EntityAlreadyExistException();
                }               
            }
            category.Name = request.Name;
            category.ModifiedAt = DateTime.Now;
            Context.SaveChanges();
        }
    }
}
