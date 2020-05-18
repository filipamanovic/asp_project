using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Brand;
using Application.Dto;
using Application.Exceptions;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        // GET: api/Brands
        [HttpGet]
        public IActionResult Get([FromQuery]BrandSearch search, [FromServices] IGetBrandsCommand _getBrands)
        {
            try
            {
                var brands = _getBrands.Execute(search);
                return Ok(brands);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error, getBrands: " +  e.Message);
            }
        }

        // GET: api/Brands/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetBrandCommand _getBrand)
        {
            try
            {
                var brand = _getBrand.Execute(id);
                return Ok(brand);
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
                return StatusCode(500, "Internal server error, getBrand: " + e.Message);
            }
        }

        // POST: api/Brands
        [HttpPost]
        public IActionResult Post([FromBody] BrandDto dto, [FromServices] IAddBrandCommand _addBrand)
        {
            try
            {
                _addBrand.Execute(dto);
                return StatusCode(201);
            }
            catch(EntityAlreadyExistException e)
            {
                return UnprocessableEntity(e.msg);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error, addBrand: " + e.Message);
            }
        }

        // PUT: api/Brands/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BrandDto dto, [FromServices] IEditBrandCommand _editBrand)
        {
            try
            {
                dto.Id = id;
                _editBrand.Execute(dto);
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
                return StatusCode(500, "Internal server error, editBrand: " + e.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteBrandCommand _deleteBrand)
        {
            try
            {
                _deleteBrand.Execute(id);
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
                return StatusCode(500, "Internal server error, deleteBrand" + e.Message);
            }
        }
    }
}
