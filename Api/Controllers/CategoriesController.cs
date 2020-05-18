using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Category;
using Application.Dto;
using Application.Exceptions;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        // GET: api/Categories
        [HttpGet]
        public IActionResult Get([FromQuery]CategorySearch search, [FromServices] IGetCategoriesCommand _getCategories)
        {
            try
            {
                var categories = _getCategories.Execute(search);
                return Ok(categories);
            }
            catch(Exception)
            {
                return StatusCode(500, "Internal server error, getCategories");
            }
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public ActionResult Get(int id, [FromServices] IGetCategoryCommand _getCategory)
        {
            try
            {
                var category = _getCategory.Execute(id);
                return Ok(category);
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

        // POST: api/Categories
        [HttpPost]
        public IActionResult Post([FromBody] CategoryDto dto, [FromServices] IAddCategoryCommand _addCategory)
        {
            try
            {
                _addCategory.Execute(dto);
                return StatusCode(201);
            }
            catch(EntityAlreadyExistException e)
            {
                return UnprocessableEntity(e.msg);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error, insertCategory.");
            }
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CategoryDto dto, [FromServices] IEditCategoryCommand _editCategory)
        {
            try
            {
                dto.Id = id;
                _editCategory.Execute(dto);
                return NoContent();
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.msg);
            }
            catch(EntityAlreadyDeletedException e)
            {
                return Conflict(e.msg);
            }
            catch(EntityAlreadyExistException e)
            {
                return UnprocessableEntity(e.msg);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error, editCategory");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCategoryCommand _deleteCategory)
        {
            try
            {
                _deleteCategory.Execute(id);
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
            catch (Exception)
            {
                return StatusCode(500, "Internal server error, deleteCategory");
            }
        }
    }
}
