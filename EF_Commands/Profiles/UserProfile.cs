using Application.Dto.UserDtoData;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Commands.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Domain.User, UserDto>();
        }
    }
}
