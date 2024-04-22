using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionHeaven.Core.Models
{
    public class DescriptionProductViewModel
    {
        public int id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Price { get; set; } = string.Empty;

        public string ImgUrl { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Brand { get; set; } = string.Empty;

        public int SizeId { get; set; }
        [Required]
        public IEnumerable<SizeViewModel> Sizes = new List<SizeViewModel>();

        public int ColourId { get; set; }
        [Required]
        public IEnumerable<ColourViewModel> Colours { get; set; } = new List<ColourViewModel>();    










    }
}
