using Application.Commands.Model;
using Application.Dto;
using Application.Exceptions;
using Domain;
using EF_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_Commands.EF_Model
{
    public class EF_AddModelCommand : EF_BaseEntity, IAddModelCommand
    {
        public EF_AddModelCommand(asp_projectContext context) : base(context) {}

        public void Execute(ModelDto request)
        {
            if (Context.Models.Any(m => m.Name.ToLower() == request.Name.ToLower()))
                throw new EntityAlreadyExistException();
            if (!Context.Brands.Any(b => b.Id == request.BrandId))
                throw new ForeinKeyNotFoundException("Brand");
            Context.Models.Add(new Model
            {
                Name = request.Name,
                Brand = Context.Brands.Find(request.BrandId)
            });
            Context.SaveChanges();
        }
    }
}
