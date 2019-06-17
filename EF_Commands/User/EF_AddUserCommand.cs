using Application.Commands.User;
using Application.Dto;
using Application.Exceptions;
using EF_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_Commands.User
{
    public class EF_AddUserCommand : EF_BaseEntity, IAddUserCommand
    {
        public EF_AddUserCommand(asp_projectContext context) : base(context)
        {
        }

        public void Execute(UserDto request)
        {
            if (Context.Users.Any(u => u.Email == request.Email))
            {
                throw new EntityAlreadyExistException();
            }

            Context.Users.Add(new Domain.User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber
            });

            Context.SaveChanges();
        }
    }
}
