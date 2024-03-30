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
    public class ProductGenderConfiguration : IEntityTypeConfiguration<ProductGender>
    {
        public void Configure(EntityTypeBuilder<ProductGender> builder)
        {
            var data = new SeedData();

            builder.HasData(new ProductGender[] {data.Kid,data.Men,data.Women});
        }
    }
}
