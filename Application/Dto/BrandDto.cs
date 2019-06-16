using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Dto
{
    public class BrandDto
    {
        [RegularExpression(@"^[a-zA-Z''-'+\s\d]{2,30}$",
         ErrorMessage = "Brand name format is not allowed.")]
        public string Name { get; set; }
        [RegularExpression(@"^[a-zA-Z\s]{2,30}$",
         ErrorMessage = "Brand City name format is not allowed.")]
        public string City { get; set; }
        [RegularExpression(@"^[a-zA-Z\s]{2,30}$",
         ErrorMessage = "Brand State name format is not allowed.")]
        public string State { get; set; }
        public string LogoUrl { get; set; }

    }
}
