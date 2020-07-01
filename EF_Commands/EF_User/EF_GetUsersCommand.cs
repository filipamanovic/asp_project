using Application.Commands.User;
using Application.Dto.UserDtoData;
using Application.Responcses;
using Application.Searches;
using AutoMapper;
using Domain;
using EF_Commands.Helpers;
using EF_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_Commands.EF_User
{
    public class EF_GetUsersCommand : EF_BaseEntity, IGetUsersCommand
    {
        private readonly IMapper _mapper;
        public EF_GetUsersCommand(asp_projectContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 27;
        public string UseCaseName => "GetUsersUsingEF";

        public PageResponse<UserDto> Execute(UserSearch request)
        {
            var query = Context.Users.AsQueryable();

            if (request.FirstName != null)
                query = query.Where(u => u.FirstName.ToLower() == request.FirstName.ToLower());
            if (request.LastName != null)
                query = query.Where(u => u.LastName.ToLower() == request.LastName.ToLower());

            query = query.Where(u => !u.IsDeleted);

            return query.Paged<UserDto, User>(request, _mapper);
        }
    }
}
