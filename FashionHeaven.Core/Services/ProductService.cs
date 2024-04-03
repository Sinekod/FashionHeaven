using FashionHeaven.Core.Contracts;
using FashionHeaven.Core.Models;
using FashionHeaven.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FashionHeaven.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly FashionHeavenContext context;
        public ProductService(FashionHeavenContext _context )
        {
           context = _context;
        }

        public async Task<IEnumerable<ProductViewModel>> ShowAllProducts()
        {
            
            var products = await context.ProductImages
                .Select(p => new ProductViewModel
                {
                    ImageUrl = p.UmgUrl,
                    ProductName = p.ProductItem.Product.Name,
                    ProductPrice = p.ProductItem.OridinalPrice.ToString(),

                }).ToListAsync();

            return products;
        }
    }
}
