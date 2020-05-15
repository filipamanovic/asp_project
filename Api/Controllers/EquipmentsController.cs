using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Equipment;
using Application.Dto;
using Application.Exceptions;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentsController : ControllerBase
    {
        // GET: api/Equipments
        [HttpGet]
        public IActionResult Get([FromQuery] EquipmentSearch search, [FromServices] IGetEquipmentsCommand _getEquipments)
        {
            try
            {
                var equipments = _getEquipments.Execute(search);
                return Ok(equipments);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal Server Error, getEquipments: " + e.Message);
            }
        }

        // GET: api/Equipments/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetEquipmentCommand _getEquipment)
        {
            try
            {
                var equipment = _getEquipment.Execute(id);
                return Ok(equipment);
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
                return StatusCode(500, "Internal server error, getEquipment: " + e.Message);
            }
        }

        // POST: api/Equipments
        [HttpPost]
        public IActionResult Post([FromBody] EquipmentDto dto, [FromServices] IAddEquipmentCommand _addEquipment)
        {
            try
            {
                _addEquipment.Execute(dto);
                return StatusCode(201);
            }
            catch (EntityAlreadyExistException e)
            {
                return UnprocessableEntity(e.msg);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error, addEquipment: " + e.Message);
            }
        }

        // PUT: api/Equipments/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EquipmentDto dto, [FromServices] IEditEquipmentCommand _editEquipment)
        {
            try
            {
                dto.Id = id;
                _editEquipment.Execute(dto);
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
            catch(Exception e)
            {
                return StatusCode(500, "Internal server error, editEquipment: " + e.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteEquipmentCommand _deleteEquipment)
        {
            try
            {
                _deleteEquipment.Execute(id);
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
                return StatusCode(500, "Internal server error, deleteEquipment: " + e.Message);
            }
        }
    }
}
