using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.FakeData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakeDataFeedController : ControllerBase
    {      
        // POST: api/FakeDataFeed
        [HttpPost]
        public IActionResult Post([FromServices] IAddFakeDataCommand _addFakeData)
        {
            try
            {
                _addFakeData.Execute();
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error, addFakeUsers: " + e.Message);
            }
        }
    }
}
