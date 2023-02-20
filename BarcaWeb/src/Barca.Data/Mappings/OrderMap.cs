using Barca.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barca.Data.Mappings
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Description).HasColumnType("varchar(200)");

            builder.HasOne(p => p.User).WithMany(c => c.Orders).HasForeignKey();

            builder.Property(c => c.RequestDate).HasColumnType("datetime");

            builder.Property(c => c.ApproveDate).HasColumnType("datetime");

            builder.Property(c => (int) c.Status).HasColumnType("integer");

            builder.ToTable("Order");
        }
    }
}
