using Application.Commands.User;
using Application.Exceptions;
using EF_DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Commands.EF_User
{
    public class EF_DeleteUserCommand : EF_BaseEntity, IDeleteUserCommand
    {
        public EF_DeleteUserCommand(asp_projectContext context) : base(context)
        {
        }

        public int Id => 30;
        public string UseCaseName => "DeleteUserUsingEF";

        public void Execute(int request)
        {
            var user = Context.Users.Find(request);
            if (user == null)
                throw new EntityNotFoundException();
            if (user.IsDeleted)
                throw new EntityAlreadyDeletedException();

            user.IsDeleted = true;
            user.DeletedAt = DateTime.Now;
            Context.SaveChanges();
        }
    }
}
