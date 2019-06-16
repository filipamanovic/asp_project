using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Brand;
using Application.Dto;
using Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IAddBrandCommand _addBrand;

        public BrandsController(IAddBrandCommand addBrand)
        {
            _addBrand = addBrand;
        }

        // GET: api/Brands
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Brands/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Brands
        [HttpPost]
        public IActionResult Post([FromBody] BrandDto dto)
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
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
