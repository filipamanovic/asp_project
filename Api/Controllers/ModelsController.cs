using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Model;
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
    public class ModelsController : ControllerBase
    {
        private readonly UseCaseExecutor _caseExecutor;

        public ModelsController(UseCaseExecutor caseExecutor)
        {
            _caseExecutor = caseExecutor;
        }

        // GET: api/Models
        [HttpGet]
        public IActionResult Get([FromQuery] ModelSearch search, [FromServices] IGetModelsCommand _getModels)
        {
            return Ok(_caseExecutor.ExecuteCommand(_getModels, search));
        }

        // GET: api/Models/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetModelCommand _getModel)
        {
            return Ok(_caseExecutor.ExecuteCommand(_getModel, id));
        }

        // POST: api/Models
        [HttpPost]
        public IActionResult Post([FromBody] ModelDto dto, [FromServices] IAddModelCommand _addModel)
        {
            _caseExecutor.ExecuteCommand(_addModel, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Models/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ModelDto dto, [FromServices] IEditModelCommand _editModel)
        {
            dto.Id = id;
            _caseExecutor.ExecuteCommand(_editModel, dto);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteModelCommand _deleteModel)
        {
            _caseExecutor.ExecuteCommand(_deleteModel, id);
            return NoContent();
        } 
    }
}
