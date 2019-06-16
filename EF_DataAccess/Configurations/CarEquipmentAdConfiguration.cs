using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_DataAccess.Configurations
{
    public class CarEquipmentAdConfiguration : IEntityTypeConfiguration<CarEquipmentAd>
    {
        public void Configure(EntityTypeBuilder<CarEquipmentAd> builder)
        {
            builder.HasKey(ca => new { ca.CarEquipmentId, ca.AdvertisementId });
        }
    }
}
