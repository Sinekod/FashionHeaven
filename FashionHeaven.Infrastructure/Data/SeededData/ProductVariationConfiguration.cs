using FashionHeaven.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionHeaven.Infrastructure.Data.SeededData
{
    public class ProductVariationConfiguration : IEntityTypeConfiguration<ProductVariation>
    {
        public void Configure(EntityTypeBuilder<ProductVariation> builder)
        {
            var data = new SeedData();
                builder
                 .HasOne(pv => pv.Size)
                 .WithMany()
                 .HasForeignKey(pv => pv.SizeId)
                 .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(new ProductVariation[] { data.JacketVariation, data.JeanVariation, data.PantsVariation, data.ShirtVariation });
        }
    }
}
