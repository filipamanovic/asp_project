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
        // GET: api/Advertisements
        [HttpGet]
        public IActionResult Get([FromQuery] AdvertisementSearch search, 
            [FromServices] IGetAdvertisementsCommand _getAdvertisements)
        {
            try
            {
                var advertisements = _getAdvertisements.Execute(search);
                return Ok(advertisements);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Internal server error, getBrands: " + e.Message);
            }
        }

        // GET: api/Advertisements/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetAdvertisementCommand _getAdvertisement)
        {
            try
            {
                var advertisement = _getAdvertisement.Execute(id);
                return Ok(advertisement);
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
                return StatusCode(500, "Internal server error, getAdvertisement: " + e.Message);
            }
        }

        // POST: api/Advertisements
        [HttpPost]
        public IActionResult Post([FromForm] AdvertisementDto dto, [FromServices] IAddAdvertisementCommand _addAdvertisement)
        {
            try
            {
                var imageUploadData = ImageUpload.UploadImagesTest(dto.Images);
                dto.ImagesInsert = imageUploadData.Select(ud => ud.Image).ToList();
                _addAdvertisement.Execute(dto);
                ImageUpload.UploadImages(imageUploadData);
                return StatusCode(200);
            }
            catch (EntityAlreadyExistException e)
            {
                return UnprocessableEntity(e.msg);
            }
            catch (ForeinKeyNotFoundException e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch (ImageUploadException e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch (DuplicateCarEquipmentException e)
            {
                return UnprocessableEntity(e.msg);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error, addAdvertisement: " + e.Message);
            }
        }

        // PUT: api/Advertisements/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AdvertisementEdit dto,
            [FromServices] IEditAdvertisementCommand _editAdvertisement)
        {
            try
            {
                dto.Id = id;
                _editAdvertisement.Execute(dto);
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
                return StatusCode(500, "Internal server error, editAdvertisement: " + e.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteAdvertisementCommand _deleteAdvertisement)
        {
            try
            {
                _deleteAdvertisement.Execute(id);
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
                return StatusCode(500, "Internal server error, deleteAdvertisement" + e.Message);
            }
        }
    }
}
