using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FashionHeaven.Infrastructure.Data.Constants.Constants.SizeConstants;

namespace FashionHeaven.Infrastructure.Data.Models
{
    public class SizeCategory
    {
        public  int Id { get; set; }
        [MaxLength(MaxLenghtSizeName)]
        public string? CategoryName { get; set; } = string.Empty;


    }
}
