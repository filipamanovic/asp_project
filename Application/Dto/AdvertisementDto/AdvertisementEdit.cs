using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Dto.AdvertisementDto
{
    public class AdvertisementEdit
    {
        public int Id { get; set; }
        [RegularExpression(@"^[a-zA-Z''-'+\s\d\.\,]{2,30}$",
            ErrorMessage = "Advertisement name format is not allowed.")]
        public string AdName { get; set; }
        [RegularExpression(@"^[A-z''-'+\s\d\.\,\*,ČĆŽŠĐčćžšđ]{2,500}$",
            ErrorMessage = "Advertisement description format is not allowed.")]
        public string AdDesc { get; set; }
        [Range(1900, 2020, ErrorMessage = "Production year from 1900 - 2020")]
        public int? ProductionYear { get; set; }
        [Range(10, 500000, ErrorMessage = "Price range from 10 - 500000")]
        public int? Price { get; set; }
        [Range(10, 10000, ErrorMessage = "Engine volume range from 10 - 10000")]
        public int? EngineVolume { get; set; }
        [Range(10, 1000, ErrorMessage = "Engine pover range from 10 - 1000")]
        public int? EnginePower { get; set; }
        [Range(0, 2000000, ErrorMessage = "Km value range from 0 - 2000000")]
        public int? KmValue { get; set; }
        public string City { get; set; }
    }
}
