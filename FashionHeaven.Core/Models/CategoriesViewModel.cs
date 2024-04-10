using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionHeaven.Core.Models
{
    public class CategoriesViewModel
    {
        public int Id { get; set; }
       
        public string CategoryName { get; set; } = string.Empty;

        public string? ColourName { get; set; } = string.Empty;

        public string Gender { get; set; } = string.Empty;

        public string? SizeName { get; set; } = string.Empty;



    }
}
