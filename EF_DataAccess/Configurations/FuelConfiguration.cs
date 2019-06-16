using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_DataAccess.Configurations
{
    public class FuelConfiguration : IEntityTypeConfiguration<Fuel>
    {
        public void Configure(EntityTypeBuilder<Fuel> builder)
        {
            builder.Property(f => f.Name).IsRequired().HasMaxLength(30);
            builder.HasIndex(f => f.Name).IsUnique();
            builder.Property(f => f.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
