using FashionHeaven.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetAllProductsAsync(int genderid)
        {
             var products = await productService.ShowAllProductsAsync(genderid);
             HttpContext.Session.SetInt32("ProductGenderId", genderid);

            return View(products);
            
        }
        
        public async Task<IActionResult> Filter(string? categoryName,string? colourName,string? sizeName,int? genderId)
        {
            genderId = HttpContext.Session.GetInt32("ProductGenderId");
            var products = await productService.FilterProducts(categoryName, colourName, sizeName,genderId);
         
            return View("GetAllProducts",products);
        }
        [HttpGet]
        public async Task<IActionResult> RemoveFilter()
        {
            return  RedirectToAction("GetAllProducts");
        
        }

    }
}
