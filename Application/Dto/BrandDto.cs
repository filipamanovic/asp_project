using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Dto
{
    public class BrandDto
    {
        public int Id { get; set; }
        [RegularExpression(@"^[A-z''-'+\s\d]{2,30}$",
         ErrorMessage = "Brand name format is not allowed.")]
        public string Name { get; set; }
        [RegularExpression(@"^[A-z\s]{2,30}$",
         ErrorMessage = "Brand City name format is not allowed.")]
        public string City { get; set; }
        [RegularExpression(@"^[A-z\s]{2,30}$",
         ErrorMessage = "Brand State name format is not allowed.")]
        public string State { get; set; }
        public string LogoUrl { get; set; }

    }
}
