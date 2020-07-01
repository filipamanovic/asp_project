using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Category;
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
    public class CategoriesController : ControllerBase
    {
        private readonly UseCaseExecutor _caseExecutor;

        public CategoriesController(UseCaseExecutor caseExecutor)
        {
            _caseExecutor = caseExecutor;
        }

        // GET: api/Categories
        [HttpGet]
        public IActionResult Get([FromQuery]CategorySearch search, [FromServices] IGetCategoriesCommand _getCategories)
        {
            return Ok(_caseExecutor.ExecuteCommand(_getCategories, search));
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public ActionResult Get(int id, [FromServices] IGetCategoryCommand _getCategory)
        {
            return Ok(_caseExecutor.ExecuteCommand(_getCategory, id));
        }

        // POST: api/Categories
        [HttpPost]
        public IActionResult Post([FromBody] CategoryDto dto, [FromServices] IAddCategoryCommand _addCategory)
        {
            _caseExecutor.ExecuteCommand(_addCategory, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CategoryDto dto, [FromServices] IEditCategoryCommand _editCategory)
        {
            dto.Id = id;
            _caseExecutor.ExecuteCommand(_editCategory, dto);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCategoryCommand _deleteCategory)
        {
            _caseExecutor.ExecuteCommand(_deleteCategory, id);
            return NoContent();
        }
    }
}
