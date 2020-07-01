using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Core;
using Application.Commands.User;
using EF_Commands.Helpers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly JwtManager _jwtManager;
        private readonly Encryption _encryption;

        public TokenController(JwtManager jwtManager, Encryption encryption)
        {
            _jwtManager = jwtManager;
            _encryption = encryption;
        }

        // POST api/<TokenController>
        [HttpPost]
        public IActionResult Post([FromBody] LoginRequest login, [FromServices] ICheckUserCommand _checkUser)
        {
            var user = _checkUser.CheckUser(login.Email, login.Password);
            if (user == null)
                throw new Exception("Incorect password");
            
            var token =_jwtManager.MakeToken(user);

            if (token == null)
                return Unauthorized();

            return Ok(new { token });
        }

        public class LoginRequest
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}
