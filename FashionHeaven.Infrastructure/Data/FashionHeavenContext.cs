﻿using FashionHeaven.Infrastructure.Data.Models;
using FashionHeaven.Infrastructure.Data.SeededData;
using FashionHeaven.Infrastructure.SeededData;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace FashionHeaven.Infrastructure.Data
{
    public class FashionHeavenContext : IdentityDbContext<ApplicationUser>
    {
        public FashionHeavenContext(DbContextOptions<FashionHeavenContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BrandConfiguration());
            builder.ApplyConfiguration(new ColourConfiguration());
            builder.ApplyConfiguration(new ProductCategoryConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ProductGenderConfiguration());
            builder.ApplyConfiguration(new ProductItemConfiguration());
            builder.ApplyConfiguration(new SizeConfiguration());
            builder.ApplyConfiguration(new ProductItemSizeColourConfiguration());
            base.OnModelCreating(builder);
        }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Colour> Colours { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductItem> ProductItems { get; set; }
        public DbSet<ProductGender> ProductGenders { get; set; }
       
        public DbSet<Size> Sizes { get; set; }
       
        public DbSet<ProductItemSizeColours> ProductsSizesColours { get; set; }
    }
}
