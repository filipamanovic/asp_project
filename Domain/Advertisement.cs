using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Advertisement : BaseEntity
    {
        public string AdName { get; set; }
        public string AdDescription { get; set; }
        public int ProductionYear { get; set; }
        public int Price { get; set; }
        public int EngineVolume { get; set; }
        public int EnginePower { get; set; }
        public int KmValue { get; set; }
        public string City { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }
        public int? CarBodyId { get; set; }
        public CarBody CarBody { get; set; }
        public int? FuelId { get; set; }
        public Fuel Fuel { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Image> Images { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<CarEquipmentAd> AdCarEquipments { get; set; }
    }
}
