using FashionHeaven.Infrastructure.Data.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FashionHeaven.Infrastructure.Data.Constants.Constants.ProductCategoryConstants;
namespace FashionHeaven.Infrastructure.Data.Models
{
    public class ProductCategory
    {
        public int Id { get; set; }

        public int GenderId { get; set; }
        [ForeignKey(nameof(GenderId))]
        public ProductGender ProductGender { get; set; } = null!;
        [MaxLength(MaxLenghtCategoryName)]
        public string CategoryName { get; set; } = string.Empty;

        public int SizeCategoryId { get; set; }
        [ForeignKey(nameof(SizeCategoryId))]
        public SizeCategory SizeCategory { get; set; } = null!;
    }
}
