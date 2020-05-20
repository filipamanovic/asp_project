using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.FakeData;
using Application.Commands.User;
using Application.Dto.UserDtoData;
using Application.Exceptions;
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
        // GET: api/Users
        [HttpGet]
        public IActionResult Get([FromQuery] UserSearch search, [FromServices] IGetUsersCommand _getUsers)
        {
            try
            {
                var users = _getUsers.Execute(search);
                return Ok(users);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal Server Error, getUsers: " + e.Message);
            }
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetUserCommand _getUser)
        {
            try
            {
                var user = _getUser.Execute(id);
                return Ok(user);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.msg);
            }
            catch (EntityAlreadyDeletedException e)
            {
                return NotFound(e.msg);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error, getUser: " + e.Message);
            }
        }

        // POST: api/Users
        [HttpPost]
        public IActionResult Post([FromBody] UserDto dto, [FromServices] IAddUserCommand _addUser)
        { 
            try
            {
                _addUser.Execute(dto);
                return StatusCode(201);
            }
            catch (EntityAlreadyExistException e)
            {
                return UnprocessableEntity(e.msg);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error, addUser: " + e.Message);
            }
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserEdit dto, [FromServices] IEditUserCommand _editUser)
        {
            try
            {
                dto.Id = id;
                _editUser.Execute(dto);
                return NoContent();
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.msg);
            }
            catch (EntityAlreadyDeletedException e)
            {
                return UnprocessableEntity(e.msg);
            }
            catch (EntityAlreadyExistException e)
            {
                return Conflict(e.msg);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error, editUser: " + e.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteUserCommand _deleteUser)
        {
            try
            {
                _deleteUser.Execute(id);
                return NoContent();
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.msg);
            }
            catch (EntityAlreadyDeletedException e)
            {
                return NotFound(e.msg);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error, deleteUser: " + e.Message);
            }
        }
    }
}
