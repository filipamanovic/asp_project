using Application.Commands.Category;
using Application.Dto;
using Application.Exceptions;
using Domain;
using EF_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_Commands.EF_Category
{
    public class EF_AddCategoryCommand : EF_BaseEntity, IAddCategoryCommand
    {
        public EF_AddCategoryCommand(asp_projectContext context) : base(context) { }

        public void Execute(CategoryDto request)
        {
            if (Context.Categories.Any(c => c.Name == request.Name))
            {
                throw new EntityAlreadyExistException();
            }

            Context.Categories.Add(new Category
            {
                Name = request.Name
            });

            Context.SaveChanges();
        }
    }
}
