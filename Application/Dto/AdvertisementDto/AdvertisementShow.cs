using System;
using System.Collections.Generic;
using System.Text;
using Application.Dto.UserDtoData;

namespace Application.Dto.AdvertisementDto
{
    public class AdvertisementShow
    {
        public string AdName { get; set; }
        public string AdDesc { get; set; }
        public int ProductionYear { get; set; }
        public int Price { get; set; }
        public int EngineVolume { get; set; }
        public int EnginePower { get; set; }
        public int KmValue { get; set; }
        public string City { get; set; }
        public string ModelName { get; set; }
        public string BrandName { get; set; }
        public string CarBodyName { get; set; }
        public string FuelName { get; set; }
        public string CategoryName { get; set; }
        public UserDto UserInfo { get; set; }
        public IEnumerable<string> ImagesData { get; set; }
        public IEnumerable<string> CarEquipmentNames { get; set; }
    }
}
