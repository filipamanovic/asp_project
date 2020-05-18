using Application.Dto.UserDtoData;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.User
{
    public interface IGetUserCommand : ICommand<int, UserDto>
    {
    }
}
