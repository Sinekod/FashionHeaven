using System.ComponentModel.DataAnnotations.Schema;

namespace FashionHeaven.Infrastructure.Data.Models
{
    public class ProductCategory
    {
        public int Id { get; set; }

        public int GenderId { get; set; }
        [ForeignKey(nameof(GenderId))]
        public ProductGender ProductGender { get; set; } = null!;

        public string CategoryName { get; set; } = string.Empty;







    }
}
