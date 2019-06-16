using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Logo { get; set; }
        public ICollection<Model> Models { get; set; }
    }
}
