using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionHeaven.Infrastructure.Data.Models
{
    public class ProductItemSizeColours
    {

        public  int ProductItemId { get; set; }
        [ForeignKey(nameof(ProductItemId))]
        public ProductItem ProductItem { get; set; } = null!;

        public int SizeId { get; set; }
        [ForeignKey(nameof(SizeId))]
        public Size Size { get; set; } = null!;
        public int ColourId { get; set; }
        [ForeignKey(nameof(ColourId))]
        public Colour Colour { get; set; } = null!;

    }
}
