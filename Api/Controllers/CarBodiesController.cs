using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.CarBody;
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
    public class CarBodiesController : ControllerBase
    {
        private readonly UseCaseExecutor _caseExecutor;

        public CarBodiesController(UseCaseExecutor caseExecutor)
        {
            _caseExecutor = caseExecutor;
        }

        // GET: api/CarBodies
        [HttpGet]
        public IActionResult Get([FromQuery] CarBodySearch search, [FromServices] IGetCarBodiesCommand _getCarBodies)
        {          
            return Ok(_caseExecutor.ExecuteCommand(_getCarBodies, search));         
        }

        // GET: api/CarBodies/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetCarBodyCommand _getCarBody)
        {          
            return Ok(_caseExecutor.ExecuteCommand(_getCarBody, id));          
        }

        // POST: api/CarBodies
        [HttpPost]
        public IActionResult Post([FromBody] CarBodyDto dto, [FromServices] IAddCarBodyCommand _addCarBody)
        {
            _caseExecutor.ExecuteCommand(_addCarBody, dto);
            return StatusCode(201);
        }

        // PUT: api/CarBodies/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CarBodyDto dto, [FromServices] IEditCarBodyCommand _editCarBody)
        {
            dto.Id = id;
            _caseExecutor.ExecuteCommand(_editCarBody, dto);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCarBodyCommand _deleteCarBody)
        {
            _caseExecutor.ExecuteCommand(_deleteCarBody, id);
            return NoContent();
        }
    }
}
