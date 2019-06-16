using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class CarBody : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Advertisement> Advertisements { get; set; }
    }
}
