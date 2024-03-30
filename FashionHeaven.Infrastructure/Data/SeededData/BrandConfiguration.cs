using FashionHeaven.Infrastructure.Data.Models;
using FashionHeaven.Infrastructure.Data.SeededData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionHeaven.Infrastructure.SeededData
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            var data = new SeedData();

            builder.HasData(new Brand[] {data.Adidas,data.Puma,data.Nike,data.NewBalance,data.Reebok});
        }
    }
}
