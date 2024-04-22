using FashionHeaven.Core.Models;
using FashionHeaven.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionHeaven.Core.Contracts
{
    public interface IProductService
    {
        public  IQueryable<ProductViewModel> ShowAllProductsAsync( int? genderid);

        public Task<IEnumerable<CategoriesViewModel>> ShowAllCategoryNamesAsync();

        public IQueryable<ProductViewModel> FilterProducts(string? categoryName, string? colourName, string? sizeName,int? genderId);

        public Task AddProduct(ProductForumAdd product);

        public Task<IEnumerable<ColourViewModel>> GetAllColoursAsync();

        public Task<bool> CheckColoursExist(int id);

        public Task<bool> CheckCategoryExist(int id);

        public Task<bool> CheckSizeExist(int id);
        public Task<bool> CheckGender(int id);

        public Task<IEnumerable<GenderViewModel>> GetAllGendersAsync();

        public Task<IEnumerable<SizeViewModel>> GetAllProductSizesAsync();

        public Task<DescriptionProductViewModel> GetDetailForProduct(int id);

        public Task<ProductItem> CheckProductItemExist(int id);

        public Task<IEnumerable<ColourViewModel>> GetColoursForTheCurrentProduct(int id);
        public Task<IEnumerable<SizeViewModel>> GetSizesForCurrentProduct(int id);
    }
}
