using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.FakeData;
using Application.Commands.User;
using Application.Dto.UserDtoData;
using Application.Exceptions;
using Application.Helpers;
using Application.Searches;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UseCaseExecutor _caseExecutor;

        public UsersController(UseCaseExecutor caseExecutor)
        {
            _caseExecutor = caseExecutor;
        }

        // GET: api/Users
        [HttpGet] [Authorize]
        public IActionResult Get([FromQuery] UserSearch search, [FromServices] IGetUsersCommand _getUsers)
        {
            return Ok(_caseExecutor.ExecuteCommand(_getUsers, search));
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetUserCommand _getUser)
        {
            return Ok(_caseExecutor.ExecuteCommand(_getUser, id));
        }

        // POST: api/Users
        [HttpPost]
        public IActionResult Post([FromBody] UserDto dto, [FromServices] IRegisterUserCommand _registerUser)
        {
            _caseExecutor.ExecuteCommand(_registerUser, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserDto dto, [FromServices] IEditUserCommand _editUser)
        {
            dto.Id = id;
            _caseExecutor.ExecuteCommand(_editUser, dto);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteUserCommand _deleteUser)
        {
            _caseExecutor.ExecuteCommand(_deleteUser, id);
            return NoContent();
        }
    }
}
