using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionHeaven.Infrastructure.Data.Models
{
    public class ProductVariation
    {
        public  int Id { get; set; }
        [ForeignKey(nameof(ProductItemId))]
        public ProductItem ProductItem { get; set; } = null!;
        public  int ProductItemId { get; set; }
        public int SizeId { get; set; }
        [ForeignKey(nameof(SizeId))]
        public Size Size { get; set; } = null!;

        public int QuantityInStock { get; set; }



    }
}
