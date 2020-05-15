using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Dto
{
    public class EquipmentDto
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'+\s\d]{2,30}$",
         ErrorMessage = "Equipment name format is not allowed.")]
        public string EquipmentName { get; set; }
    }
}
