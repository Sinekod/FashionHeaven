using FashionHeaven.Core.Contracts;
using FashionHeaven.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FashionHeaven.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService cartService;
        private readonly IProductService productService;
        public CartController(ICartService _cartService)
        {
            cartService = _cartService;
        }

        public Task<IEnumerable<CartItem>> CartItems()
        {
            return cartService.GetAllCartItemsAsync();
        }

        public async Task AddCartItem(int id,int colourid,int sizeId)
        {
            if (!await productService.CheckProductColorSizeExist(id,colourid,sizeId))
            {
                ModelState.AddModelError(nameof(id),"Product does not exist");
            }
            if (ModelState.IsValid)
            {
                await cartService.AddItemInCartAsync(id, colourid,sizeId);
            }

        }
    }
}
