using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FashionHeaven.Core.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string  ImageUrl { get; set; } = string.Empty;

        public string ProductPrice { get; set; } = string.Empty;
        
        public string ProductName { get; set; } = string.Empty;

        public string ProductCategory { get; set; } = string.Empty;

        public string SizeName { get; set; } = string.Empty;

        public int GenderId { get; set; } 

    }
}
