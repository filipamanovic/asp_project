using Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Dto.AdvertisementDto
{
    public class AdvertisementDto
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'+\s\d\.\,]{2,30}$",
            ErrorMessage = "Advertisement name format is not allowed.")]
        public string AdName { get; set; }
        [Required]
        [RegularExpression(@"^[A-z''-'+\s\d\.\,\*,ČĆŽŠĐčćžšđ]{2,500}$",
            ErrorMessage = "Advertisement description format is not allowed.")]
        public string AdDesc { get; set; }
        [Required]
        [Range(1900, 2020, ErrorMessage = "Production year from 1900 - 2020")]
        public int ProductionYear { get; set; }
        [Required]
        [Range(10, 500000, ErrorMessage = "Price range from 10 - 500000")]
        public int Price { get; set; }
        [Required]
        [Range(10, 10000, ErrorMessage = "Engine volume range from 10 - 10000")]
        public int EngineVolume { get; set; }
        [Required]
        [Range(10, 1000, ErrorMessage = "Engine pover range from 10 - 1000")]
        public int EnginePower { get; set; }
        [Required]
        [Range(0, 2000000, ErrorMessage = "Km value range from 0 - 2000000")]
        public int KmValue { get; set; }
        [Required]
        [RegularExpression(@"^[A-z''-'+\s\d\.\,\*,ČĆŽŠĐčćžšđ]{2,50}$",
                        ErrorMessage = "City format is not allowed.")]
        public string City { get; set; }
        [RegularExpression(@"^[1-9][\d]*$", ErrorMessage = "Model id is required")]
        public int ModelId { get; set; }
        [RegularExpression(@"^[1-9][\d]*$", ErrorMessage = "Carbody id is required")]
        public int CarBodyId { get; set; }
        [RegularExpression(@"^[1-9][\d]*$", ErrorMessage = "Fuel id is required")]
        public int FuelId { get; set; }
        public int CategoryId { get; set; } = 1;
        [RegularExpression(@"^[1-9][\d]*$", ErrorMessage = "User id is required")]
        public int UserId { get; set; }
        public IEnumerable<IFormFile> Images { get; set; }
        public List<int> CarEquipments { get; set; }
        public ICollection<CarEquipmentAd> AdCarEquipmentsInsert { get; set; }
        public List<Image> ImagesInsert { get; set; }
    }
}
