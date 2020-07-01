using Application.Dto;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.User
{
    public interface ICheckUserCommand
    {
        Domain.User CheckUser(string email, string password);
    }
}
