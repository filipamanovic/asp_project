using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.UseCaseLog;
using Application.Helpers;
using Application.Searches;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserUseCaseLogs : ControllerBase
    {
        private readonly UseCaseExecutor _caseExecutor;

        public UserUseCaseLogs(UseCaseExecutor caseExecutor)
        {
            _caseExecutor = caseExecutor;
        }

        // GET: api/<UserUseCaseLogs>
        [HttpGet]
        public IActionResult Get([FromQuery] LogSearch search, [FromServices] IGetUseCaseLogsCommand _getUseCaseLogs)
        {
            return Ok(_caseExecutor.ExecuteCommand(_getUseCaseLogs, search));
        }
    }
}
