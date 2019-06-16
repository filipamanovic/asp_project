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
        private IAddCategoryCommand _addCategory;
        private IGetCategoriesCommand _getCategories;
        private IGetCategoryCommand _getCategory;
        private IDeleteCategoryCommand _deleteCategory;
        private IEditCategoryCommand _editCategory;

        public CategoriesController(IAddCategoryCommand addCategory, IGetCategoriesCommand getCategories, IGetCategoryCommand getCategory, IDeleteCategoryCommand deleteCategory, IEditCategoryCommand editCategory)
        {
            _addCategory = addCategory;
            _getCategories = getCategories;
            _getCategory = getCategory;
            _deleteCategory = deleteCategory;
            _editCategory = editCategory;
        }



        // GET: api/Categories
        [HttpGet]
        public IActionResult Get([FromQuery]CategorySearch search)
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
        public ActionResult Get(int id)
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
            catch (Exception)
            {
                return StatusCode(500, "Inteernal server error, getCategory");
            }
        }

        // POST: api/Categories
        [HttpPost]
        public IActionResult Post([FromBody] CategoryDto dto)
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
        public IActionResult Put(int id, [FromBody] CategoryDto dto)
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
        public IActionResult Delete(int id)
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
