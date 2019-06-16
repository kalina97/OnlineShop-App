using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccess.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {

        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(pc => pc.BrandName).IsRequired();
            builder.HasIndex(pc => pc.BrandName).IsUnique();
            builder.Property(u => u.CreatedAt).HasDefaultValueSql("GETDATE()");

           

        }
    }
}
