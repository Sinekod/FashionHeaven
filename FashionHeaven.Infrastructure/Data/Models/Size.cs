using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FashionHeaven.Infrastructure.Data.Constants.Constants.SizeConstants;
namespace FashionHeaven.Infrastructure.Data.Models
{
    public class Size
    {
        public  int Id { get; set; }
        [MaxLength(MaxLenghtSizeName)]
        public string SizeName { get; set; } = string.Empty;

        public int SizeCategoryId { get; set; }
        [ForeignKey(nameof(SizeCategoryId))]
        public SizeCategory SizeCategory { get; set; } = null!;
        


    }
}