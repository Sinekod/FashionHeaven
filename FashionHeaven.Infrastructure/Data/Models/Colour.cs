
using System.ComponentModel.DataAnnotations;
using static FashionHeaven.Infrastructure.Data.Constants.Constants.ColourConstants;
namespace FashionHeaven.Infrastructure.Data.Models
{
    public class Colour
    {
        public int Id { get; set; }
         [MaxLength(MaxLenghtColourName)]
        public string ColourName { get; set; } = string.Empty;

       

    }
}