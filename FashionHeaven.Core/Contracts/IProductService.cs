using FashionHeaven.Core.Models;
using FashionHeaven.Infrastructure.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionHeaven.Core.Contracts
{
    public interface IProductService
    {
        public  Task<IEnumerable<ProductViewModel>> ShowAllProductsAsync( int genderid);

        public Task<IEnumerable<CategoriesViewModel>> ShowAllCategoryNamesAsync();

        public Task<IEnumerable<ProductViewModel>> FilterProducts(string? categoryName, string? colourName, string? sizeName,int? genderId);
    }
}
