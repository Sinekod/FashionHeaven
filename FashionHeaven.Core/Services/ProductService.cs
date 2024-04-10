using FashionHeaven.Core.Contracts;
using FashionHeaven.Core.Models;
using FashionHeaven.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FashionHeaven.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly FashionHeavenContext context;
        public ProductService(FashionHeavenContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<CategoriesViewModel>> ShowAllCategoryNamesAsync()
        {
            var categories = await context.ProductItems.AsNoTracking()
            .Select(p => new CategoriesViewModel()
            {
               Id = p.Id,
               CategoryName = p.Product.Category.CategoryName,
               ColourName = p.Colour.ColourName,
               SizeName = p.SizeName.SizeName,
                
            }).ToListAsync();
            
            return categories;
        }
        public async Task<IEnumerable<ProductViewModel>> FilterProducts(string? categoryName, string? colourName, string? sizeName,int? genderId)
        {
            var products = await context.ProductImages.
                Where(p => p.ProductItem.Product.Category.CategoryName == categoryName ||
                p.ProductItem.Colour.ColourName == colourName ||
                p.ProductItem.SizeName.SizeName == sizeName)
            .Select(p => new ProductViewModel
            {
                ImageUrl = p.UmgUrl,
                ProductName = p.ProductItem.Product.Name,
                ProductPrice = p.ProductItem.OridinalPrice.ToString(),
                ProductCategory = p.ProductItem.Product.Category.CategoryName,
                SizeName = p.ProductItem.SizeName.SizeName,
                GenderId = p.ProductItem.Product.Category.GenderId

            }).ToListAsync();
           
            return products.Where(p=>p.GenderId==genderId);

        }

        public async Task<IEnumerable<ProductViewModel>> ShowAllProductsAsync(int genderid)
        {
            var products = await context.ProductImages.
             Where(p =>p.ProductItem.Product.Category.ProductGender.Id == genderid)
            .Select(p => new ProductViewModel
            {
                ImageUrl = p.UmgUrl,
                ProductName = p.ProductItem.Product.Name,
                ProductPrice = p.ProductItem.OridinalPrice.ToString(),
                ProductCategory = p.ProductItem.Product.Category.CategoryName,
                SizeName = p.ProductItem.SizeName.SizeName,
                GenderId = p.ProductItem.Product.Category.GenderId

            }).ToListAsync();
            
            return products;

        }

        
    }
}
