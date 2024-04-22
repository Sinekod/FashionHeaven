using FashionHeaven.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionHeaven.Infrastructure.Data.SeededData
{
    internal class ProductItemSizeColourConfiguration : IEntityTypeConfiguration<ProductItemSizeColours>
    {
        public void Configure(EntityTypeBuilder<ProductItemSizeColours> builder)
        {
            builder.HasKey(p=> new {p.ProductItemId,p.SizeId,p.ColourId });
            var data = new SeedData();

            builder.HasData(new ProductItemSizeColours[] {data.Product1,data.Product2,data.Product3,data.Product4});

        }
    }
}
