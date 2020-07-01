using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Advertisement;
using Application.Dto.AdvertisementDto;
using Application.Exceptions;
using Application.Helpers;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementsController : ControllerBase
    {
        private readonly UseCaseExecutor _caseExecutor;

        public AdvertisementsController(UseCaseExecutor caseExecutor)
        {
            _caseExecutor = caseExecutor;
        }

        // GET: api/Advertisements
        [HttpGet]
        public IActionResult Get([FromQuery] AdvertisementSearch search, 
            [FromServices] IGetAdvertisementsCommand _getAdvertisements)
        {
            return Ok(_caseExecutor.ExecuteCommand(_getAdvertisements, search));
        }

        // GET: api/Advertisements/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetAdvertisementCommand _getAdvertisement)
        {
            return Ok(_caseExecutor.ExecuteCommand(_getAdvertisement, id));
        }

        // POST: api/Advertisements
        [HttpPost]
        public IActionResult Post([FromForm] AdvertisementDto dto, [FromServices] IAddAdvertisementCommand _addAdvertisement)
        {
            if (dto.Images != null)
            {
                var imageUploadData = ImageUpload.UploadImagesTest(dto.Images);
                dto.ImagesInsert = imageUploadData.Select(ud => ud.Image).ToList();
                _caseExecutor.ExecuteCommand(_addAdvertisement, dto);
                ImageUpload.UploadImages(imageUploadData);
            }  
            else
            {
                _caseExecutor.ExecuteCommand(_addAdvertisement, dto);
            }
           
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Advertisements/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AdvertisementEdit dto,
            [FromServices] IEditAdvertisementCommand _editAdvertisement)
        {
            dto.Id = id;
            _caseExecutor.ExecuteCommand(_editAdvertisement, dto);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteAdvertisementCommand _deleteAdvertisement)
        {
            _caseExecutor.ExecuteCommand(_deleteAdvertisement, id);
            return NoContent();
        }
    }
}
