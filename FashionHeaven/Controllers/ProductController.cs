using FashionHeaven.Core.Contracts;
using FashionHeaven.Core.Models;
using FashionHeaven.Core.Services;
using FashionHeaven.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace FashionHeaven.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductService productService;

        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await productService.ShowAllProducts();
          
            return View(products);
        }


    }
}
