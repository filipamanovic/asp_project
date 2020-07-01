using Application.Commands.User;
using Application.Dto.UserDtoData;
using Application.Exceptions;
using EF_Commands.Validators;
using EF_DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_Commands.EF_User
{
    public class EF_EditUserCommand : EF_BaseEntity, IEditUserCommand
    {
        private readonly EditUserValidator _editUserValidator;
        public EF_EditUserCommand(asp_projectContext context, EditUserValidator validations) : base(context)
        {
            _editUserValidator = validations;
        }

        public int Id => 29;
        public string UseCaseName => "EditUserUsingEF";

        public void Execute(UserDto request)
        {
            _editUserValidator.ValidateAndThrow(request);
            var user = Context.Users.Find(request.Id);
            if (user == null)
                throw new EntityNotFoundException();
            if (user.IsDeleted == true)
                throw new EntityAlreadyDeletedException();

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
