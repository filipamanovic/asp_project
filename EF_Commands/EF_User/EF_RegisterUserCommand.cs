using Application.Commands.Email;
using Application.Commands.User;
using Application.Dto.UserDtoData;
using Domain;
using EF_Commands.Helpers;
using EF_Commands.Validators;
using EF_DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace EF_Commands.EF_User
{
    public class EF_RegisterUserCommand : EF_BaseEntity, IRegisterUserCommand
    {
        private readonly RegisterUserValidator _registerUserValidator;
        private readonly Encryption _encryption;
        private readonly IEmailSender _emailSender;

        public EF_RegisterUserCommand(asp_projectContext context, RegisterUserValidator registerUserValidator,
                Encryption encryption, IEmailSender emailSender) : base(context)
        {
            _registerUserValidator = registerUserValidator;
            _encryption = encryption;
            _emailSender = emailSender;
        }

        public int Id => 26;
        public string UseCaseName => "RegisterUserUsingEF";

        public void Execute(UserDto request)
        {
            _registerUserValidator.ValidateAndThrow(request);

            //Only GET and GET/Id
            List<int> allowedUseCases = new List<int> { 37, 38, 3, 2, 12, 13, 17, 18, 33, 32, 23, 22, 7, 8, 27, 28 }; 
            List<UserUseCase> authorizedUseCases = new List<UserUseCase>();
            foreach (var x in allowedUseCases)
                authorizedUseCases.Add(new UserUseCase { UseCaseId = x });

            Context.Users.Add(new Domain.User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Password = _encryption.EncryptString(request.Password),
                UserUseCases = authorizedUseCases
            });

            Context.SaveChanges();

            _emailSender.Send(new Application.Dto.SendEmailDto
            {
                Content = "<h3>Successfull registration</h3>",
                SendTo = request.Email,
                Subject = "Registration"
            });
        }
    }
}
