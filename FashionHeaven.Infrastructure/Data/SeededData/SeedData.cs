using FashionHeaven.Infrastructure.Data.Models;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionHeaven.Infrastructure.Data.SeededData
{
    public class SeedData
    {
        public SeedData()
        {
            SeedBrands();
            SeedColours();
            SeedProductGender();
            SedSize();
            ProductSeed();
            SeedProductCategory();
            SeedProductItem();
            
            SeedProductItemSizeColour();
        }

        //ProductItemSizeColour
        public ProductItemSizeColours Product1 { get; set; }
        public ProductItemSizeColours Product2 { get; set; }
        public ProductItemSizeColours Product3 { get; set; }

        public ProductItemSizeColours Product4 { get; set; }

        //Brands
        public Brand Nike { get; set; }
        public Brand Adidas { get; set; }
        public Brand Puma { get; set; }
        public Brand Reebok { get; set; }
        public Brand NewBalance { get; set; }
        //Colour
        public Colour Red { get; set; }
        public Colour Blue { get; set; }
        public Colour Green { get; set; }
        public Colour Pink { get; set; }

        public Colour Black { get; set; }
        //Size
        public Size S { get; set; }

        public Size M { get; set; }

        public Size L { get; set; }

        public Size XL { get; set; }


        //Product Gender

        public ProductGender Men { get; set; }

        public ProductGender Women { get; set; }

        public ProductGender Kid { get; set; }



        //Product

        public Product JacketName { get; set; }

        public Product PantsName { get; set; }

        public Product ShirtName { get; set; }

        public Product JeansName { get; set; }

        //Product Categories

        public ProductCategory Jacket { get; set; }

        public ProductCategory Pants { get; set; }

        public ProductCategory Shirt { get; set; }

        public ProductCategory Jeans { get; set; }

        //Product Item

        public ProductItem JacketItem { get; set; }

        public ProductItem PantsItem { get; set; }

        public ProductItem ShirtItem { get; set; }

        public ProductItem JeansItem { get; set; }


        

        public void SeedProductItemSizeColour()
        {
            Product1 = new ProductItemSizeColours()
            {
                ProductItemId = JacketItem.Id,
                ColourId = Red.Id,
                SizeId = S.Id


            };
            Product2 = new ProductItemSizeColours()
            {
                ProductItemId = PantsItem.Id,
                ColourId = Blue.Id,
                SizeId = M.Id


            };
            Product3 = new ProductItemSizeColours()
            {
                ProductItemId = ShirtItem.Id,
                ColourId = Green.Id,
                SizeId = L.Id


            };
            Product4 = new ProductItemSizeColours()
            {
                ProductItemId = JeansItem.Id,
                ColourId = Black.Id,
                SizeId = XL.Id


            };


        }

       

        public void SeedProductItem()
        {
            JacketItem = new ProductItem()
            {
                Id = 1,
                ProductId = JacketName.Id,
                
                OridinalPrice = 100,
                SalePrice = 80,
                ImgUrl = "https://www.asphaltgold.com/cdn/shop/files/e28c112df2824d87e6d428611d0d7b2dfb59d2c0_FB7368_657_Nike_Club_Puffer_Jacket_University_Red_White_os_1_1200x1200.jpg?v=1707749646",
                QuantityInStock = 50
            };
            PantsItem = new ProductItem()
            {
                Id = 2,
                ProductId = PantsName.Id,
               
                OridinalPrice = 50,
                SalePrice = 30,
                ImgUrl = "https://static.ftshp.digital/img/p/1/0/7/2/5/7/3/1072573-full_product.jpg",
                QuantityInStock = 50
            };


            ShirtItem = new ProductItem()
            {
                Id = 3,
                ProductId = ShirtName.Id,
             
                OridinalPrice = 30,
                SalePrice = 20,
                ImgUrl = "https://i.ebayimg.com/images/g/gq4AAOSwj29i9Hmg/s-l1600.jpg",
                QuantityInStock = 50
            };
            JeansItem = new ProductItem()
            {
                Id = 4,
                ProductId = JeansName.Id,
            
                OridinalPrice = 120,
                SalePrice = 90,
                ImgUrl = "https://images.hugoboss.com/is/image/boss/hbeu50501329_015_100?$re_fullPageZoom$&qlt=85&fit=crop,1&align=1,1&lastModified=1705957483000&wid=1200&hei=1818",
                QuantityInStock = 50

            };

        }

        public void SeedProductCategory()
        {

            Jacket = new ProductCategory
            {
                Id = 1,
                GenderId = Men.Id,
                CategoryName = "Jacket",


            };

            Pants = new ProductCategory
            {
                Id = 2,
                GenderId = Women.Id,
                CategoryName = "Pants",


            };

            Shirt = new ProductCategory
            {
                Id = 3,
                GenderId = Men.Id,
                CategoryName = "Shirt",


            };

            Jeans = new ProductCategory
            {
                Id = 4,
                GenderId = Kid.Id,
                CategoryName = "Jeans",


            };


        }

        public void ProductSeed()
        {
            JacketName = new Product()
            {
                Id = 1,
                Name = "JacketName",
                Description = "Test for the jeans",
                BrandId = 1,
                CategoryId = 1,

            };
            PantsName = new Product()
            {
                Id = 2,
                Name = "PantsName",
                Description = "Very good",
                BrandId = 2,
                CategoryId = 2,

            };

            JeansName = new Product()
            {
                Id = 3,
                Name = "JeansName",
                Description = "Very very good",
                BrandId = 3,
                CategoryId = 4,
            };
            ShirtName = new Product
            {
                Id = 4,
                Name = "ShirtName",
                Description = "Very good for winter",
                BrandId = 4,
                CategoryId = 3,

            };

        }


        public void SedSize()
        {
            S = new Size()
            {
                Id = 1,
                SizeName = "Small",


            };

            M = new Size()
            {
                Id = 2,
                SizeName = "Medium",

            };

            L = new Size()
            {
                Id = 3,
                SizeName = "Large",

            };

            XL = new Size()
            {
                Id = 4,
                SizeName = "ExtraLarge",


            };

        }
        public void SeedProductGender()
        {
            Men = new ProductGender()
            {
                Id = 1,
                GenderName = "Men"

            };

            Women = new ProductGender()
            {
                Id = 2,
                GenderName = "Women"


            };

            Kid = new ProductGender()
            {
                Id = 3,
                GenderName = "Kids"
            };


        }
        public void SeedColours()
        {
            Red = new Colour()
            {
                Id = 1,
                ColourName = "Red"
            };
            Blue = new Colour()
            {
                Id = 2,
                ColourName = "Blue"
            };
            Green = new Colour()
            {
                Id = 3,
                ColourName = "Green"

            };
            Pink = new Colour()
            {
                Id = 4,
                ColourName = "Pink"
            };
            Black = new Colour()
            {
                Id = 5,
                ColourName = "Black"

            };




        }
        public void SeedBrands()
        {
            Nike = new Brand()
            {
                Id = 1,
                BrandName = "Nike"
            };
            Adidas = new Brand()
            {
                Id = 2,
                BrandName = "Adidas"
            };

            Puma = new Brand()
            {
                Id = 3,
                BrandName = "Puma"
            };

            Reebok = new Brand()
            {
                Id = 4,
                BrandName = "Reebok"
            };

            NewBalance = new Brand()
            {
                Id = 5,
                BrandName = "New Balance"
            };

        }

    }
}
