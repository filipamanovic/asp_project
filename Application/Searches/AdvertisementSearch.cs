using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class AdvertisementSearch
    {
        public string Name { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public int? ProductionYearMin { get; set; }
        public int? ProductionYearMax { get; set; }
        public int? EngiveVolumeMin { get; set; }
        public int? EngineVolumeMax { get; set; }
        public int? EnginePowerMin { get; set; }
        public int? EnginePowerMax { get; set; }
        public int? KmValueMin { get; set; }
        public int? KmValueMax { get; set; }
        public string City { get; set; }
        public int? ModelId { get; set; }
        public int? CarBodyId { get; set; }
        public int? FuelId { get; set; }
        public int CategoryId { get; set; } = 1;
        public int? BrandId { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int PerPage { get; set; } = 2;
    }
}
