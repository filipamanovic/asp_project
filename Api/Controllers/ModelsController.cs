using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Model;
using Application.Dto;
using Application.Exceptions;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        // GET: api/Models
        [HttpGet]
        public IActionResult Get([FromQuery] ModelSearch search, [FromServices] IGetModelsCommand _getModels)
        {
            try
            {
                var models = _getModels.Execute(search);
                return Ok(models);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error, getModels: " + e.Message);
            }
        }

        // GET: api/Models/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetModelCommand _getModel)
        {
            try
            {
                var model = _getModel.Execute(id);
                return Ok(model);
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
                return StatusCode(500, "Internal server error, getModel: " + e.Message);
            }
        }

        // POST: api/Models
        [HttpPost]
        public IActionResult Post([FromBody] ModelDto dto, [FromServices] IAddModelCommand _addModel)
        {
            try
            {
                _addModel.Execute(dto);
                return StatusCode(201);
            }
            catch (EntityAlreadyExistException e)
            {
                return UnprocessableEntity(e.msg);
            }
            catch (ForeinKeyNotFoundException e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error, addModel: " + e.Message);
            }
        }

        // PUT: api/Models/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ModelDto dto, [FromServices] IEditModelCommand _editModel)
        {
            try
            {
                dto.Id = id;
                _editModel.Execute(dto);
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
                return StatusCode(500, "Internal server error, editModel: " + e.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteModelCommand _deleteModel)
        {
            try
            {
                _deleteModel.Execute(id);
                return NoContent();
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.msg);
            }
            catch (EntityAlreadyDeletedException e)
            {
                return Conflict(e.msg);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error, deleteModel" + e.Message);
            }
        } 
    }
}
