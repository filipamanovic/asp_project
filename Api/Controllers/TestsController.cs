using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Application.Exceptions;
using Application.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        // GET: api/Tests
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Tests/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Tests
        [HttpPost]
        public IActionResult Post([FromForm] ImageUploadTest images)
        {
            try
            {
                //var imagesUploaded = ImageUpload.UploadImagesT(images.Images);
                return StatusCode(201);
            }
            catch (ImageUploadException e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error, editFuel: " + e.Message);
            }
        }

        // PUT: api/Tests/5
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

    public class ImageUploadTest
    {
        public IEnumerable<IFormFile> Images { get; set; }
    }
}
