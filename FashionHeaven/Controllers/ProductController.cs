using FashionHeaven.Core.Contracts;
using FashionHeaven.Core.Models;
using FashionHeaven.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;

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
        public async Task<IActionResult> GetAllProductsAsync(int genderid, int pageNumber)
        {
            var products = productService.ShowAllProductsAsync(genderid);
            HttpContext.Session.SetInt32("ProductGenderId", genderid);
            HttpContext.Session.SetInt32("PageNumbers", pageNumber);

            if (pageNumber < 1)
            {
                pageNumber = 1;
            }
            int pageSize = 1;
            return View(await PeginatedList<ProductViewModel>.CreateAsync(products, pageNumber, pageSize));

        }

        public async Task<IActionResult> Filter(string? categoryName, string? colourName, string? sizeName, int? genderId)
        {
            genderId = HttpContext.Session.GetInt32("ProductGenderId");
            var products = productService.FilterProducts(categoryName, colourName, sizeName, genderId);
            int pageSize = 1;
            int? pageNumber = HttpContext.Session.GetInt32("PageNumbers");

            if (pageNumber == null || pageNumber<1)
            {
                pageNumber = 1;
            }
            return View("GetAllProducts",await PeginatedList<ProductViewModel>.CreateAsync(products, Convert.ToInt32(pageNumber), pageSize));
        }
        [HttpGet]
        public async Task<IActionResult> RemoveFilter()
        {
             int? genderId = HttpContext.Session.GetInt32("ProductGenderId");
            var products = productService.ShowAllProductsAsync(genderId);
            return View("GetAllProducts", products);
        }
        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            var product = new ProductForumAdd
            {
               Gender = await productService.GetAllGendersAsync(),
               Categories = await productService.ShowAllCategoryNamesAsync(),
               Colours = await productService.GetAllColoursAsync(),
               Sizes= await productService.GetAllProductSizesAsync(),
            };


            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductForumAdd model)
        {
            if (!await productService.CheckCategoryExist(model.CategoryId))
            {
                ModelState.AddModelError(nameof(model.CategoryId),"Category does not exist");
            }
            if (!await productService.CheckColoursExist(model.GenderId))
            {
                ModelState.AddModelError(nameof(model.GenderId), "Gender does not exist");
            }
            if (!await productService.CheckColoursExist(model.ColourId))
            {
                ModelState.AddModelError(nameof(model.ColourId), "Colour does not exist");
            }
            if (!await productService.CheckSizeExist(model.SizeId))
            {
                ModelState.AddModelError(nameof(model.ColourId), "Size does not exist");
            }
            if (!ModelState.IsValid)
            {
                model.Gender = await productService.GetAllGendersAsync();
                model.Categories = await productService.ShowAllCategoryNamesAsync();
                model.Colours = await productService.GetAllColoursAsync();
                model.Sizes = await productService.GetAllProductSizesAsync();
                return View(model);
                
            }

            await productService.AddProduct(model);
            return View("SuccesFullyAddedProduct");

        }
        [HttpGet]
        public async Task<IActionResult> ViewProductDetails(int id)
        {
            var model = await productService.GetDetailForProduct(id);
            if (model==null)
            {
                return BadRequest();
            }
            
            return View(model);


        }
        public async Task<IActionResult> BackToHomePage()
        {
            return RedirectToAction("Index","Home");

        
        }

    }
}
