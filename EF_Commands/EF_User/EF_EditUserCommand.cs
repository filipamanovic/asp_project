using Application.Commands.User;
using Application.Dto.UserDtoData;
using Application.Exceptions;
using EF_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_Commands.EF_User
{
    public class EF_EditUserCommand : EF_BaseEntity, IEditUserCommand
    {
        public EF_EditUserCommand(asp_projectContext context) : base(context)
        {
        }

        public void Execute(UserEdit request)
        {
            var user = Context.Users.Find(request.Id);
            if (user == null)
                throw new EntityNotFoundException();
            if (user.IsDeleted == true)
                throw new EntityAlreadyDeletedException();
            if (user.Email != request.Email && request.Email != null)
                if (Context.Users.Any(u => u.Email.ToLower() == request.Email.ToLower()))
                    throw new EntityAlreadyExistException();

            if (request.FirstName != null)
                user.FirstName = request.FirstName;
            if (request.LastName != null)
                user.LastName = request.LastName;
            if (request.Email != null)
                user.Email = request.Email;
            if (request.PhoneNumber != null)
                user.PhoneNumber = request.PhoneNumber;

            Context.SaveChanges();
        }
    }
}
