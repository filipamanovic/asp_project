using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.FakeData;
using Application.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakeDataFeedController : ControllerBase
    {
        private readonly UseCaseExecutor _caseExecutor;

        public FakeDataFeedController(UseCaseExecutor caseExecutor)
        {
            _caseExecutor = caseExecutor;
        }

        // POST: api/FakeDataFeed
        [HttpPost]
        public IActionResult Post([FromServices] IAddFakeDataCommand _addFakeData)
        {
            _caseExecutor.ExecuteCommand(_addFakeData);
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
