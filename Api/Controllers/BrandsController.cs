using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Brand;
using Application.Dto;
using Application.Exceptions;
using Application.Helpers;
using Application.Interfaces;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly UseCaseExecutor _caseExecutor;

        public BrandsController(UseCaseExecutor caseExecutor)
        {
            _caseExecutor = caseExecutor;
        }

        // GET: api/Brands
        [HttpGet]
        public IActionResult Get([FromQuery]BrandSearch search, [FromServices] IGetBrandsCommand _getBrands)
        {
            return Ok(_caseExecutor.ExecuteCommand(_getBrands, search));
        }

        // GET: api/Brands/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetBrandCommand _getBrand)
        {
            return Ok(_caseExecutor.ExecuteCommand(_getBrand, id));
        }

        // POST: api/Brands
        [HttpPost]
        public IActionResult Post([FromBody] BrandDto dto, [FromServices] IAddBrandCommand _addBrand)
        {
            _caseExecutor.ExecuteCommand(_addBrand, dto);
            return StatusCode(201);
        }

        // PUT: api/Brands/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BrandDto dto, [FromServices] IEditBrandCommand _editBrand)
        {
            dto.Id = id;
            _caseExecutor.ExecuteCommand(_editBrand, dto);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteBrandCommand _deleteBrand)
        {
            _caseExecutor.ExecuteCommand(_deleteBrand, id);
            return NoContent();
        }
    }
}
