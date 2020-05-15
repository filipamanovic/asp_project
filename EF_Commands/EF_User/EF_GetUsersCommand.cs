using Application.Commands.User;
using Application.Dto.UserDto;
using Application.Searches;
using EF_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_Commands.EF_User
{
    public class EF_GetUsersCommand : EF_BaseEntity, IGetUsersCommand
    {
        public EF_GetUsersCommand(asp_projectContext context) : base(context)
        {
        }

        public IEnumerable<UserDto> Execute(UserSearch request)
        {
            var query = Context.Users.AsQueryable();

            if (request.FirstName != null)
                query.Where(u => u.FirstName.ToLower() == request.FirstName.ToLower());
            if (request.LastName != null)
                query.Where(u => u.LastName.ToLower() == request.LastName.ToLower());

            return query.Where(u => !u.IsDeleted).Select(u => new UserDto
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber
            });
        }
    }
}
