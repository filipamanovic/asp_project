using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_DataAccess.Configurations
{
    public class CarEquipmentConfiguration : IEntityTypeConfiguration<CarEquipment>
    {
        public void Configure(EntityTypeBuilder<CarEquipment> builder)
        {
            builder.Property(c => c.EquipmentName).IsRequired().HasMaxLength(50);
            builder.HasIndex(c => c.EquipmentName).IsUnique();
            builder.Property(c => c.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.HasMany(c => c.CarEquipmentAds)
                .WithOne(ce => ce.CarEquipment)
                .HasForeignKey(ce => ce.CarEquipmentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
