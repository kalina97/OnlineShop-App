using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccess.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(p => p.Quantity).IsRequired();
            builder.Property(u => u.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.HasMany(c => c.OrderProducts)
                .WithOne(cp => cp.Order)
                .HasForeignKey(cp => cp.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(u => u.User)
                   .WithMany(o => o.Orders)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}

