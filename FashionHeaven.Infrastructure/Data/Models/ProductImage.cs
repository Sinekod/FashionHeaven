using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionHeaven.Infrastructure.Data.Models
{
    public class ProductImage
    {
        public int Id { get; set; }

        public int ProductItemId { get; set; }
        [ForeignKey(nameof(ProductItemId))]
        public ProductItem ProductItem { get; set; } = null!;

        public string UmgUrl { get; set; } = string.Empty;


    }
}
