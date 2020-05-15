using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    public class ImageUploadException : Exception
    {
        public ImageUploadException(string msg) : base("Image upload exception: " + msg) { }
    }
}
