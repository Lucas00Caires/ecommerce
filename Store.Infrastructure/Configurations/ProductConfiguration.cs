using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasConversion(x => x.ToString(), x => x)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("varchar(100)");

            builder.Property(x => x.Description)
                .HasConversion(x => x.ToString(), x => x)
                .HasColumnName("Description")
                .HasColumnType("varchar(250)");

            builder.Property(x => x.Price)
               .IsRequired()
               .HasColumnName("Price")
               .HasColumnType("decimal")
               .HasPrecision(6,2);


        }
    }
}
