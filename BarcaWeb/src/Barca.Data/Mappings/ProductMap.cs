using Barca.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dev.Data.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Name).HasColumnType("varchar(200)");

            builder.Property(p => p.Description).HasColumnType("varchar(200)");

            //builder.Property(p => p.Price).HasColumnType("decimal(20)");

            builder.HasOne(p => p.Category).WithMany(c => c.Product).HasForeignKey(p => p.CategoryID);

            builder.ToTable("M_PRODUCT");
        }
    }
}
