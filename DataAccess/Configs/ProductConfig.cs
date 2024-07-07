using ApplicationCore.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configs
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(x=> x.Id);

            builder.Property(x=> x.Name).HasMaxLength(250).IsRequired();
            builder.Property(x=>x.Price).IsRequired();
            builder.Property(x=> x.Quantity).IsRequired();
            builder.Property(x=> x.CategoryId).IsRequired();    
        }
    }
}
