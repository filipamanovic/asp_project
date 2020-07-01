using Application.Commands.User;
using Application.Dto.UserDtoData;
using Application.Exceptions;
using EF_DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Commands.EF_User
{
    public class EF_GetUserCommand : EF_BaseEntity, IGetUserCommand
    {
        public EF_GetUserCommand(asp_projectContext context) : base(context)
        {
        }

        public int Id => 28;
        public string UseCaseName => "GetUserUsingEF";

        public UserDto Execute(int request)
        {
            var user = Context.Users.Find(request);
            if (user == null)
                throw new EntityNotFoundException();
            if (user.IsDeleted)
                throw new EntityAlreadyDeletedException();
            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };
        }
    }
}
