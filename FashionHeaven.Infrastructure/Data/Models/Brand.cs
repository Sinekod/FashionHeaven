using System.ComponentModel.DataAnnotations;
using static FashionHeaven.Infrastructure.Data.Constants.Constants.BrandConstants;
namespace FashionHeaven.Infrastructure.Data.Models
{
    public class Brand
    {
        public  int Id { get; set; }
        [MaxLength(MaxLenghtBrandName)]
        public string BrandName { get; set; } = string.Empty;

       

    }
}