using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccess.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(pc => pc.RoleName).IsRequired();
            builder.HasIndex(pc => pc.RoleName).IsUnique();
            builder.Property(u => u.CreatedAt).HasDefaultValueSql("GETDATE()");
        }

    }
}
