using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Dto
{
    public class FuelDto
    {
        public int Id { get; set; }
        [RegularExpression(@"^[a-zA-Z''-'+\s\d]{2,30}$",
         ErrorMessage = "Fuel name format is not allowed.")]
        public string Name { get; set; }
    }
}
