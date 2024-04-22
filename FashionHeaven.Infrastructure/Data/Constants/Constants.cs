using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionHeaven.Infrastructure.Data.Constants
{
    public static class Constants
    {

        public static class ApplicationUserConstants
        {
            public const int MaxLenghtUserName = 20;
            public const int MinLenghtUserName = 4;
        }

        public static class ProductCategoryConstants
        {
          public const int MaxLenghtCategoryName = 40;        
        
        
        }
        public static class ProductConstants 
        {
            public const int MaxLenghtProductName = 40;
            public const int MaxLenghtDescriptionProduct = 1500;
        
        
        }
        public static class ColourConstants 
        {
            public const int MaxLenghtColourName = 50;
        
        }
        public static class BrandConstants 
        {
            public const int MaxLenghtBrandName = 50;

        }
        public static class SizeConstants
        {
            public const int MaxLenghtSizeName = 50;

        }


    }
}
