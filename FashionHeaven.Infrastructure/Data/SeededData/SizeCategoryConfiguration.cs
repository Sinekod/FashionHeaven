using FashionHeaven.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionHeaven.Infrastructure.Data.SeededData
{
    public class SizeCategoryConfiguration : IEntityTypeConfiguration<SizeCategory>
    {
        public void Configure(EntityTypeBuilder<SizeCategory> builder)
        {
           var data = new SeedData();

            builder.HasData(new SizeCategory[] {data.SmallJeans,data.MediumPants,data.LargeJacket,data.ExtraLargeShirt });
        }
    }
}
