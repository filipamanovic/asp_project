using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class CarEquipmentAd
    {
        public int CarEquipmentId { get; set; }
        public CarEquipment CarEquipment { get; set; }
        public int AdvertisementId { get; set; }
        public Advertisement Advertisement { get; set; }
    }
}
