using Application.Commands.User;
using Application.Exceptions;
using EF_Commands.Helpers;
using EF_DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EF_Commands.EF_User
{
    public class EF_CheckUserCommand : EF_BaseEntity, ICheckUserCommand
    {
        private readonly Encryption _encryption;
        public EF_CheckUserCommand(asp_projectContext context, Encryption encryption) : base(context)
        {
            _encryption = encryption;
        }

        public Domain.User CheckUser(string email, string password)
        {
            var user = Context.Users.Where(u => u.Email.ToLower() == email.ToLower())
                .Include(u => u.UserUseCases).FirstOrDefault();
            if (user == null)
                throw new UnregistredUserException();

            var passwordToCheck = _encryption.DecryptString(user.Password);
               
            passwordToCheck = Regex.Replace(passwordToCheck, @"[^\u0020-\u007E]", string.Empty);
            //var index = passwordToCheck.IndexOf("\b");
            //var passwordToCheck2 = passwordToCheck.Substring(0, index);

            if (passwordToCheck == password)
                return user;

            return null;
        }
    }
}
