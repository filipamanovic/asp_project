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
        public CategoryDto Execute(int request)
        {
            var category = Context.Categories.Find(request);
            if (category == null)
            {
                throw new EntityNotFoundException();
            }
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
            
        }
    }
}
