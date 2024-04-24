using FashionHeaven.Core.Contracts;
using FashionHeaven.Core.Models;
using FashionHeaven.Infrastructure.Data;
using FashionHeaven.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionHeaven.Core.Services
{
    public class CartService : ICartService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IProductService productService;
        private readonly FashionHeavenContext context;
        
        public CartService(IHttpContextAccessor httpContextAccessor, IProductService productService, FashionHeavenContext context)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.productService = productService;
            this.context = context;
        }

        public async Task AddItemInCartAsync(int id, int colourId,int sizeId)
        {
            var cartItem = await context.ProductsSizesColours.Where(p=>p.ProductItemId==id && p.ColourId== colourId).Select(p=> new CartItem 
            { 
                
              Brand = p.ProductItem.Product.Brand.BrandName,
              ProductName = p.ProductItem.Product.Name,
              Price = p.ProductItem.OridinalPrice.ToString(),
              ImgUrl= p.ProductItem.ImgUrl,
              
            }).FirstOrDefaultAsync();

            var cartItemSeriliaside = JsonConvert.SerializeObject(cartItem);
            httpContextAccessor.HttpContext.Session.SetString("CartItems",cartItemSeriliaside);

        }

        public async Task<IEnumerable<CartItem>> GetAllCartItemsAsync()
        {
            List<CartItem> cartItems = new List<CartItem>();
            string cartItemSerializer = await Task.FromResult(httpContextAccessor.HttpContext.Session.GetString("ShoppingCart"));
            cartItems = JsonConvert.DeserializeObject<List<CartItem>>(cartItemSerializer);
            return cartItems;
        }

        public Task RemoveItemInCartAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
