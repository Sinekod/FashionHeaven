using Microsoft.AspNetCore.Routing.Constraints;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionHeaven.Infrastructure.Data.Models
{
    public class ProductItem
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;
        public int SizeId { get; set; }
        [ForeignKey(nameof(SizeId))]
        public Size SizeName { get; set; } = null!;
        public int ColourId { get; set; }
        [ForeignKey(nameof(ColourId))]
        public Colour Colour { get; set; } = null!;

        public decimal OridinalPrice { get; set; }

        public decimal SalePrice { get; set; }
        public int QuantityInStock { get; set; }

    }
}
