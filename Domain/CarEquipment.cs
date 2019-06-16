using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class CarEquipment : BaseEntity
    {
        public string EquipmentName { get; set; }
        public ICollection<CarEquipmentAd> CarEquipmentAds { get; set; }
    }
}
