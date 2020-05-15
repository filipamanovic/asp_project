using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_DataAccess.Configurations
{
    public class CarBodyConfiguration : IEntityTypeConfiguration<CarBody>
    {
        public void Configure(EntityTypeBuilder<CarBody> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(30);
            builder.HasIndex(c => c.Name).IsUnique();
        }
    }
}
