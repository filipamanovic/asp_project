﻿using System;
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
        private readonly IAddBrandCommand _addBrand;
        private readonly IGetBrandsCommand _getBrands;
        private readonly IGetBrandCommand _getBrand;
        private readonly IDeleteBrandCommand _deleteBrand;
        private readonly IEditBrandCommand _editBrand;

        public BrandsController(IAddBrandCommand addBrand, IGetBrandsCommand getBrands, IGetBrandCommand getBrand, IDeleteBrandCommand deleteBrand, IEditBrandCommand editBrand)
        {
            _addBrand = addBrand;
            _getBrands = getBrands;
            _getBrand = getBrand;
            _deleteBrand = deleteBrand;
            _editBrand = editBrand;
        }

        // GET: api/Brands
        [HttpGet]
        public IActionResult Get([FromQuery]BrandSearch search)
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
        public IActionResult Get(int id)
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
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error, getFuel: " + e.Message);
            }
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
        public IActionResult Put(int id, [FromBody] BrandDto dto)
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
                return StatusCode(500, "Internal server error, editFuel: " + e.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
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
                return StatusCode(500, "Internal server error, deleteFuel" + e.Message);
            }
        }
    }
}
