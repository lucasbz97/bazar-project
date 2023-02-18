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
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).HasColumnType("varchar(200)");

            //builder.HasMany(c => c.Product).WithOne(p => p.Category).HasForeignKey(c => c.CategoryID);

            builder.ToTable("M_CATEGORY");
        }
    }
}
