using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.CarBody;
using Application.Dto;
using Application.Exceptions;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarBodiesController : ControllerBase
    {
        // GET: api/CarBodies
        [HttpGet]
        public IActionResult Get([FromQuery] CarBodySearch search, [FromServices] IGetCarBodiesCommand _getCarBodies)
        {
            try
            {
                var carbodies = _getCarBodies.Execute(search);
                return Ok(carbodies);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error, getCategories");
            }
        }

        // GET: api/CarBodies/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetCarBodyCommand _getCarBody)
        {
            try
            {
                var carBody = _getCarBody.Execute(id);
                return Ok(carBody);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.msg);
            }
            catch (EntityAlreadyDeletedException e)
            {
                return NotFound(e.msg);
            }
            catch (Exception)
            {
                return StatusCode(500, "Inteernal server error, getCategory");
            }
        }

        // POST: api/CarBodies
        [HttpPost]
        public IActionResult Post([FromBody] CarBodyDto dto, [FromServices] IAddCarBodyCommand _addCarBody)
        {
            try
            {
                _addCarBody.Execute(dto);
                return StatusCode(201);
            }
            catch (EntityAlreadyExistException e)
            {
                return UnprocessableEntity(e.msg);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error, insertCarBody." + e.Message);
            }
        }

        // PUT: api/CarBodies/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CarBodyDto dto, [FromServices] IEditCarBodyCommand _editCarBody)
        {
            try
            {
                dto.Id = id;
                _editCarBody.Execute(dto);
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
                return StatusCode(500, "Internal server error, editFuel: " + e.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCarBodyCommand _deleteCarBody)
        {
            try
            {
                _deleteCarBody.Execute(id);
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
                return StatusCode(500, "Internal server error, deleteCarBody" + e.Message);
            }
        }
    }
}
