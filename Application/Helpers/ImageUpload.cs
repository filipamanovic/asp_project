using Application.Exceptions;
using Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Application.Helpers
{
    public class ImageUpload
    {
        public static IEnumerable<string> AllowedExtensions => new List<string> { ".jpeg", ".jpg", ".png", ".gif" };


        public static List<ImageUploadDto> UploadImagesTest(IEnumerable<IFormFile> images)
        {
            if (images.Count() > 5)
                throw new ImageUploadException("limit exceeded, max 5 images");
            if (images.Any(i => !ImageUpload.AllowedExtensions.Contains(Path.GetExtension(i.FileName))))
                throw new ImageUploadException("format not allowed, allowed: jpg, jpeg, png, gif");

            List<ImageUploadDto> dto = new List<ImageUploadDto>();
           
            foreach (var image in images)
            {
                var newFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                dto.Add(new ImageUploadDto
                {
                    Name = newFileName,
                    Image = new Image
                    {
                        Src = newFileName,
                        Alt = newFileName,
                    },
                    ImageFile = image
                });

            }
            return dto;
        }

        public static void UploadImages(List<ImageUploadDto> dto)
        {
            foreach (var image in dto)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads", image.Name);
                image.ImageFile.CopyTo(new FileStream(filePath, FileMode.Create));
            }
        }

    }
}
