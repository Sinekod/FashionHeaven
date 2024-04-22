using FashionHeaven.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using static FashionHeaven.Core.Constants.Constants.ConstantsForm;
using static FashionHeaven.Core.Constants.MessageConstants;
namespace FashionHeaven.Core.Models
{
    public class ProductForumAdd
    {
        public int Id { get; set; }
        [Required(ErrorMessage =RequiredMessage)]
        [Display(Name ="Product name")]
        [StringLength(MaxProductNameLenght,MinimumLength = MinProductNameLenght,ErrorMessage = LengthMessage)]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Product ImgUrl")]
        public string ImgUrl { get; set; } = string.Empty;
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Product quantity")]
        [Range(MinQuantity,MaxQuantity,ErrorMessage = LengthMessage)]
        public int Quantity { get; set; }
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Product price")]
        [Range(MinPrice, MaxPrice, ErrorMessage = LengthMessage)]
        public decimal Price { get; set; }
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Product brand")]
        [StringLength(MaxBrandNameLenght, MinimumLength = MinBrandNameLenght, ErrorMessage = LengthMessage)]
        [RegularExpression("^[A-Z].*$",ErrorMessage = BrandError)]
        public string Brand { get; set; } = string.Empty;
      
        public int SizeId { get; set; }
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Product Sizes")]
        public IEnumerable<SizeViewModel> Sizes { get; set; } = new List<SizeViewModel>();
        public int GenderId { get; set; }
        [Required(ErrorMessage = RequiredMessage)]
        public IEnumerable<GenderViewModel> Gender = new List<GenderViewModel>();
        [Required(ErrorMessage = RequiredMessage)]
        public  int CategoryId { get; set; }
        public IEnumerable<CategoriesViewModel> Categories { get; set; } = new List<CategoriesViewModel>();
        [Required(ErrorMessage = RequiredMessage)]
        public int ColourId { get; set; }
        [Required (ErrorMessage = RequiredMessage)]
        public IEnumerable<ColourViewModel> Colours { get; set; } = new List<ColourViewModel>();
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MaxDescriptionLenght,MinimumLength = MinBrandNameLenght,ErrorMessage = LengthMessage)]
        public string Description { get; set; } = string.Empty;



    }
}
