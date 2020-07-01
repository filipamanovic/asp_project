 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Fuel;
using Application.Dto;
using Application.Exceptions;
using Application.Helpers;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelsController : ControllerBase
    {
        private readonly UseCaseExecutor _caseExecutor;

        public FuelsController(UseCaseExecutor caseExecutor)
        {
            _caseExecutor = caseExecutor;
        }

        // GET: api/Fuels
        [HttpGet]
        public IActionResult Get([FromQuery] FuelSearch search, [FromServices] IGetFuelsCommand _getFuels)
        {
            return Ok(_caseExecutor.ExecuteCommand(_getFuels, search));
        }

        // GET: api/Fuels/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetFuelCommand _getFuel)
        {
            return Ok(_caseExecutor.ExecuteCommand(_getFuel, id));
        }

        // POST: api/Fuels
        [HttpPost]
        public IActionResult Post([FromBody] FuelDto dto, [FromServices] IAddFuelCommand _addFuel)
        {
            _caseExecutor.ExecuteCommand(_addFuel, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Fuels/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] FuelDto dto, [FromServices] IEditFuelCommand _editFuel)
        {         
            dto.Id = id;
            _caseExecutor.ExecuteCommand(_editFuel, dto);
            return NoContent();           
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteFuelCommand _deleteFuel)
        {
            _caseExecutor.ExecuteCommand(_deleteFuel, id);
            return NoContent();
        }
    }
}
