using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Image : BaseEntity
    {
        public string Src { get; set; }
        public string Alt { get; set; }
        public int AdvertisementId { get; set; }
        public Advertisement Advertisement { get; set; }
    }
}
