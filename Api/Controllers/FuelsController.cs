 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Fuel;
using Application.Dto;
using Application.Exceptions;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelsController : ControllerBase
    {
        private readonly IAddFuelCommand _addFuel;
        private readonly IGetFuelsCommand _getFuels;
        private readonly IGetFuelCommand _getFuel;
        private readonly IDeleteFuelCommand _deleteFuel;
        private readonly IEditFuelCommand _editFuel;

        public FuelsController(IAddFuelCommand addFuel, IGetFuelsCommand getFuels, IGetFuelCommand getFuel, IDeleteFuelCommand deleteFuel, IEditFuelCommand editFuel)
        {
            _addFuel = addFuel;
            _getFuels = getFuels;
            _getFuel = getFuel;
            _deleteFuel = deleteFuel;
            _editFuel = editFuel;
        }



        // GET: api/Fuels
        [HttpGet]
        public IActionResult Get([FromQuery] FuelSearch search)
        {
            try
            {
                var fuels = _getFuels.Execute(search);
                return Ok(fuels);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal Server Error, getFuels: " + e.Message);
            }
        }

        // GET: api/Fuels/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var fuel = _getFuel.Execute(id);
                return Ok(fuel);
            }
            catch(EntityNotFoundException e)
            {
                return NotFound(e.msg);
            }
            catch (EntityAlreadyDeletedException e)
            {
                return NotFound(e.msg);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error, getFuel: " + e.Message);
            }
        }

        // POST: api/Fuels
        [HttpPost]
        public IActionResult Post([FromBody] FuelDto dto)
        {
            try
            {
                _addFuel.Execute(dto);
                return StatusCode(201);
            }
            catch(EntityAlreadyExistException e)
            {
                return UnprocessableEntity(e.msg);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error, addFuel: " + e.Message);
            }
        }

        // PUT: api/Fuels/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] FuelDto dto)
        {
            try
            {
                dto.Id = id;
                _editFuel.Execute(dto);
                return NoContent();
            }
            catch(EntityNotFoundException e)
            {
                return NotFound(e.msg);
            }
            catch(EntityAlreadyDeletedException e)
            {
                return UnprocessableEntity(e.msg);
            }
            catch(EntityAlreadyExistException e)
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
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteFuel.Execute(id);
                return NoContent();
            }
            catch(EntityNotFoundException e)
            {
                return NotFound(e.msg);
            }
            catch(EntityAlreadyDeletedException e)
            {
                return Conflict(e.msg);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error, deleteFuel" + e.Message);
            }
        }
    }
}
