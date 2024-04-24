using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionHeaven.Core.Models
{
    public class CartItem
    {
        public string ProductName { get; set; } = string.Empty;

        public string Brand { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;

        public string ImgUrl { get; set; } = string.Empty;
        public int Quantity { get; set; }

    }
}
