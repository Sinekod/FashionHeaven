using FashionHeaven.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionHeaven.Core.Contracts
{
    public interface IProductService
    {
        public  Task<IEnumerable<ProductViewModel>> ShowAllProducts();
    }
}
