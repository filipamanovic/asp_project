using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Equipment;
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
    public class EquipmentsController : ControllerBase
    {
        private readonly UseCaseExecutor _caseExecutor;

        public EquipmentsController(UseCaseExecutor caseExecutor)
        {
            _caseExecutor = caseExecutor;
        }

        // GET: api/Equipments
        [HttpGet]
        public IActionResult Get([FromQuery] EquipmentSearch search, [FromServices] IGetEquipmentsCommand _getEquipments)
        {
            return Ok(_caseExecutor.ExecuteCommand(_getEquipments, search));
        }

        // GET: api/Equipments/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetEquipmentCommand _getEquipment)
        {
            return Ok(_caseExecutor.ExecuteCommand(_getEquipment, id));
        }

        // POST: api/Equipments
        [HttpPost]
        public IActionResult Post([FromBody] EquipmentDto dto, [FromServices] IAddEquipmentCommand _addEquipment)
        {
            _caseExecutor.ExecuteCommand(_addEquipment, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Equipments/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EquipmentDto dto, [FromServices] IEditEquipmentCommand _editEquipment)
        {
            dto.Id = id;
            _caseExecutor.ExecuteCommand(_editEquipment, dto);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteEquipmentCommand _deleteEquipment)
        {
            _caseExecutor.ExecuteCommand(_deleteEquipment, id);
            return NoContent();
        }
    }
}
