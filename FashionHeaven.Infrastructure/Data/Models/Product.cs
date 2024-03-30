using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FashionHeaven.Infrastructure.Data.Constants.Constants.ProductConstants;

namespace FashionHeaven.Infrastructure.Data.Models
{
    public class Product
    {
        public  int Id { get; set; }
        [MaxLength(MaxLenghtProductName)]
        public  string  Name { get; set; }  = string.Empty;
        [MaxLength(MaxLenghtDescriptionProduct)]
        public string Description { get; set; } = string.Empty;

        public int BrandId { get; set; }
        [ForeignKey(nameof(BrandId))]
        public Brand Brand { get; set; } = null!;
        [ForeignKey(nameof(CategoryId))]
        public ProductCategory Category { get; set; } = null!;

        public int CategoryId { get; set; } 
    }
}
