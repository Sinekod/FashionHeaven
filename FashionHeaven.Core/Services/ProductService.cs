using FashionHeaven.Core.Contracts;
using FashionHeaven.Core.Models;
using FashionHeaven.Infrastructure.Data;
using FashionHeaven.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using System.Diagnostics;

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

            var categories = await context.ProductsSizesColours.AsNoTracking()
            .Select(p => new CategoriesViewModel()
            {
                Id = p.ProductItem.Id,
                CategoryName = p.ProductItem.Product.Category.CategoryName,
                ColourName = p.Colour.ColourName,
                SizeName = p.Size.SizeName,

            }).ToListAsync();


            return categories.DistinctBy(p => p.CategoryName);
        }
        public IQueryable<ProductViewModel> FilterProducts(string? categoryName, string? colourName, string? sizeName, int? genderId)
        {
            var products = context.ProductsSizesColours.AsNoTracking().
                Where(p => p.ProductItem.Product.Category.CategoryName == categoryName ||
                p.Colour.ColourName == colourName ||
                p.Size.SizeName == sizeName)
            .Select(p => new ProductViewModel
            {
                ImageUrl = p.ProductItem.ImgUrl,
                ProductName = p.ProductItem.Product.Name,
                ProductPrice = p.ProductItem.OridinalPrice.ToString(),
                ProductCategory = p.ProductItem.Product.Category.CategoryName,
                GenderId = p.ProductItem.Product.Category.GenderId

            });

            return products.Where(p => p.GenderId == genderId);

        }

        public IQueryable<ProductViewModel> ShowAllProductsAsync(int? genderid)
        {
            var products = context.ProductItems.AsNoTracking().
             Where(p => p.Product.Category.ProductGender.Id == genderid)
            .Select(p => new ProductViewModel
            {
                Id = p.Id,
                ImageUrl = p.ImgUrl,
                ProductName = p.Product.Name,
                ProductPrice = p.OridinalPrice.ToString(),
                ProductCategory = p.Product.Category.CategoryName,

                GenderId = p.Product.Category.GenderId

            });

            return products;

        }

        public async Task AddProduct(ProductForumAdd model)
        {
            if (!await CheckBrand(model.Brand))
            {
                await CreateBrands(model.Brand);
            }
            var brand = await context.Brands.FirstOrDefaultAsync(b => b.BrandName == model.Brand);

            var productAlreadyExist = await context.Products.FirstOrDefaultAsync(p => p.Name == model.Name
            && p.Brand.BrandName == model.Brand && p.CategoryId == model.CategoryId && p.Category.GenderId == model.GenderId && p.Description == model.Description);

            var sizesId = await context.Sizes.FirstOrDefaultAsync(p => p.Id == model.SizeId);

            if (productAlreadyExist == null)
            {
                productAlreadyExist = new Product()
                {
                    Name = model.Name,
                    Description = model.Description,
                    CategoryId = model.CategoryId,
                    BrandId = brand.Id,

                };
                await context.AddAsync(productAlreadyExist);
            }

            var productItemExist = await context.ProductItems.
                FirstOrDefaultAsync(p => p.Product == productAlreadyExist && p.QuantityInStock == model.Quantity && p.OridinalPrice == model.Price);

            if (productItemExist == null)
            {
                productItemExist = new ProductItem()
                {
                    Product = productAlreadyExist,
                    QuantityInStock = model.Quantity,
                    OridinalPrice = model.Price,
                    ImgUrl = model.ImgUrl,
                };

                await context.AddAsync(productItemExist);
            }
            var productItemSizeColourAlreadyExist = await context.ProductsSizesColours.
                FirstOrDefaultAsync(p => p.ProductItem == productItemExist && p.ColourId == model.ColourId && p.SizeId == sizesId.Id);

            if (productItemSizeColourAlreadyExist == null)
            {
                productItemSizeColourAlreadyExist = new ProductItemSizeColours()
                {
                    ProductItem = productItemExist,
                    Size = sizesId,
                    ColourId = model.ColourId,

                };
                await context.AddAsync(productItemSizeColourAlreadyExist);
            }


            await context.SaveChangesAsync();

        }

        public async Task<IEnumerable<ColourViewModel>> GetAllColoursAsync()
        {
            return await context.Colours.AsNoTracking().Select(c => new ColourViewModel
            {
                Id = c.Id,
                ColourName = c.ColourName
            }).ToListAsync();
        }

        public async Task<bool> CheckColoursExist(int id) => await context.Colours.AnyAsync(c => c.Id == id);

        public async Task<bool> CheckCategoryExist(int id) => await context.ProductCategories.AnyAsync(c => c.Id == id);

        public async Task<bool> CheckSizeExist(int id) => await context.Sizes.AnyAsync(c => c.Id == id);

        public async Task<bool> CheckGender(int id) => await context.ProductGenders.AnyAsync(c => c.Id == id);

        public async Task<bool> CheckBrand(string name) => await context.Brands.AnyAsync(c => c.BrandName == name);



        private async Task CreateBrands(string name)
        {
            Brand brand = new Brand()
            {
                BrandName = name

            };
            await context.Brands.AddAsync(brand);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GenderViewModel>> GetAllGendersAsync()
        {
            return await context.ProductGenders.AsNoTracking().Select(g => new GenderViewModel
            {
                Id = g.Id,
                Gender = g.GenderName

            }).ToListAsync();
        }

        public async Task<IEnumerable<SizeViewModel>> GetAllProductSizesAsync()
        {
            return await context.Sizes.AsNoTracking().Select(s => new SizeViewModel
            {
                Id = s.Id,
                SizeName = s.SizeName,
            }).ToListAsync();
        }

        public async Task<DescriptionProductViewModel> GetDetailForProduct(int id)
        {
            IEnumerable<SizeViewModel> sizes = await GetSizesForCurrentProduct(id);
            IEnumerable<ColourViewModel> colours = await GetColoursForTheCurrentProduct(id);
            var model = await context.ProductItems.Where(p => p.Id == id).Select(p => new DescriptionProductViewModel()
            {
                id = p.Id,
                ImgUrl = p.ImgUrl,
                Price = p.OridinalPrice.ToString(),
                Name = p.Product.Name,
                Description = p.Product.Description,
                Brand = p.Product.Brand.BrandName,
                
            }).FirstOrDefaultAsync();
            var modelDescription = new DescriptionProductViewModel()
            {
                id = model.id,
                ImgUrl = model.ImgUrl,
                Price = model.Price,
                Name = model.Name,
                Description = model.Description,
                Brand = model.Brand,
                Sizes = sizes,
                Colours = colours

            };

            return modelDescription;
        }

        public async Task<ProductItem> CheckProductItemExist(int id)
        {

            return null;
        }

        public async Task<IEnumerable<ColourViewModel>> GetColoursForTheCurrentProduct(int id)
        {
            return await context.ProductsSizesColours.Where(p => p.ProductItemId == id)
                .Select(p => new ColourViewModel()
                {
                    Id = p.ColourId,
                    ColourName = p.Colour.ColourName,

                }).ToListAsync();
        }

        public async Task<IEnumerable<SizeViewModel>> GetSizesForCurrentProduct(int id)
        {
            return await context.ProductsSizesColours.Where(p => p.ProductItemId == id)
                .Select(p => new SizeViewModel()
                {
                    Id = p.SizeId,
                    SizeName = p.Size.SizeName,

                }).ToListAsync();
        }
    }
}
