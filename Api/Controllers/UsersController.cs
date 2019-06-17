using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.User;
using Application.Dto;
using Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAddUserCommand _addUser;

        public UsersController(IAddUserCommand addUser)
        {
            _addUser = addUser;
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Users
        [HttpPost]
        public IActionResult Post([FromBody] UserDto dto)
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
                return StatusCode(500, "Internal server error, addBrand: " + e.Message);
            }
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
