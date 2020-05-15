using Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Helpers
{
    public class ImageUploadDto
    {
        public Image Image { get; set; }
        public string Name { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
