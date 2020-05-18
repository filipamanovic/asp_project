using Application.Dto.UserDtoData;
using Application.Interfaces;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.User
{
    public interface IGetUsersCommand : ICommand<UserSearch, IEnumerable<UserDto>>
    {
    }
}
