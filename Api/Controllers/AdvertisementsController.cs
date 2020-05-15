using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Advertisement;
using Application.Dto.AdvertisementDto;
using Application.Exceptions;
using Application.Helpers;
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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Advertisements/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
