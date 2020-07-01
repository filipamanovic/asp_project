using Application.Dto.UserDtoData;
using Application.Interfaces;
using Application.Responcses;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.User
{
    public interface IGetUsersCommand : ICommand<UserSearch, PageResponse<UserDto>>
    {
    }
}
