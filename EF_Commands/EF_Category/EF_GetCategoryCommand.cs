using Application.Commands.Category;
using Application.Dto;
using Application.Exceptions;
using EF_DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Commands.EF_Category
{
    public class EF_GetCategoryCommand : EF_BaseEntity, IGetCategoryCommand
    {
        public EF_GetCategoryCommand(asp_projectContext context) : base(context) { }

        public int Id => 18;
        public string UseCaseName => "GetCategoryUsingEF";

        public CategoryDto Execute(int request)
        {
            var category = Context.Categories.Find(request);
            if (category == null)
            {
                throw new EntityNotFoundException();
            }
            if(category.IsDeleted) 
                throw new EntityAlreadyDeletedException();
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
            
        }
    }
}
