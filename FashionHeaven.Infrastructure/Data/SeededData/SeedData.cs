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
            SizeCategorySeed();
            ProductSeed();
            SeedProductCategory();
            SeedProductItem();
            SeedProductVariations();
            SeedImageProduct();
        }

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

        //Size Category
        public SizeCategory SmallJeans { get; set; }

        public SizeCategory MediumPants { get; set; }

        public SizeCategory LargeJacket { get; set; }

        public SizeCategory ExtraLargeShirt { get; set; }

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

        //Product variations

        public ProductVariation JeanVariation { get; set; }
        public ProductVariation PantsVariation { get; set; }

        public ProductVariation ShirtVariation { get; set; }
        public ProductVariation JacketVariation { get; set; }
        //Product image
        public ProductImage JacketImage { get; set; }

        public ProductImage PantsImage { get; set; }

        public ProductImage ShirtImage { get; set; }

        public ProductImage JeansImage { get; set; }


        public void SeedImageProduct()
        {
            JacketImage = new ProductImage()
            {
                Id = 1,
                UmgUrl = "https://www.asphaltgold.com/cdn/shop/files/e28c112df2824d87e6d428611d0d7b2dfb59d2c0_FB7368_657_Nike_Club_Puffer_Jacket_University_Red_White_os_1_1200x1200.jpg?v=1707749646",
                ProductItemId = 1,
            
            };
            PantsImage = new ProductImage()
            { 
              Id=2,
              UmgUrl = "https://static.ftshp.digital/img/p/1/0/7/2/5/7/3/1072573-full_product.jpg",
              ProductItemId = 2,
              

            };

            ShirtImage = new ProductImage()
            {
                Id = 3,
                UmgUrl = "https://i.ebayimg.com/images/g/gq4AAOSwj29i9Hmg/s-l1600.jpg",
                ProductItemId = 3,

            };
            JeansImage = new ProductImage()
            {
                Id=4,
                UmgUrl = "https://images.hugoboss.com/is/image/boss/hbeu50501329_015_100?$re_fullPageZoom$&qlt=85&fit=crop,1&align=1,1&lastModified=1705957483000&wid=1200&hei=1818",
                ProductItemId = 4,

            };
            
        
        
        }
        public void SeedProductVariations()
        { 
            JacketVariation = new ProductVariation()
            { 
              Id = 1,
              ProductItemId = 1,
              SizeId = 2,
              QuantityInStock = 50,
            
            };
            PantsVariation = new ProductVariation()
            {
                Id= 2,
                ProductItemId = 2,
                SizeId = 3,
                QuantityInStock= 30,    

            };
            ShirtVariation = new ProductVariation()
              {
                  Id = 3,
                  ProductItemId = 3,
                  SizeId = 1,
                  QuantityInStock = 25,

              };
            JeanVariation = new ProductVariation()
            { 
              Id = 4,
              ProductItemId = 4,
              SizeId= 4,
               QuantityInStock = 80
            
            
            };


        }
        public void SeedProductItem()
        {
            JacketItem = new ProductItem()
            {
                Id = 1,
                ProductId = 1,
                ColourId = 1,
                OridinalPrice = 100,
                SalePrice = 80,

            };
            PantsItem = new ProductItem()
            {
                Id = 2,
                ProductId = 2,
                ColourId = 2,
                OridinalPrice = 50,
                SalePrice = 30,

            };


            ShirtItem = new ProductItem()
            {
                Id  = 3,
                ProductId = 3,
                ColourId = 3,
                OridinalPrice = 30,
                SalePrice= 20,
            };
            JeansItem= new ProductItem()
            {
                Id = 4,
                ProductId = 4,
                ColourId = 5,
                OridinalPrice = 120,
                SalePrice = 90,

            };



        }

        public void SeedProductCategory()
        {

            Jacket = new ProductCategory
            {
                Id = 1,
                GenderId = 1,
                CategoryName = "Jacket",
                SizeCategoryId = 3,

            };

            Pants = new ProductCategory
            {
                Id = 2,
                GenderId = 2,
                CategoryName = "Pants",
                SizeCategoryId = 2,

            };

            Shirt = new ProductCategory
            {
                Id = 3,
                GenderId = 1,
                CategoryName = "Shirt",
                SizeCategoryId = 4,

            };

            Jeans = new ProductCategory
            {
                Id = 4,
                GenderId = 3,
                CategoryName = "Jeans",
                SizeCategoryId = 1,

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

        public void SizeCategorySeed()
        {
            SmallJeans = new SizeCategory()
            {
                Id = 1,
                CategoryName = "SmallJean"

            };

            MediumPants = new SizeCategory()
            {
                Id = 2,
                CategoryName = "MediumPants"
            };

            LargeJacket = new SizeCategory()
            {
                Id = 3,
                CategoryName = "LargeJacket"
            };


            ExtraLargeShirt = new SizeCategory()
            {
                Id = 4,
                CategoryName = "ExtraLargeShirt"


            };

        }
        public void SedSize()
        {
            S = new Size()
            {
                Id = 1,
                SizeName = "Small",
                SizeCategoryId = 1,

            };

            M = new Size()
            {
                Id = 2,
                SizeName = "Medium",
                SizeCategoryId = 2,
            };

            L = new Size()
            {
                Id = 3,
                SizeName = "Large",
                SizeCategoryId = 3,
            };

            XL = new Size()
            {
                Id = 4,
                SizeName = "ExtraLarge",
                SizeCategoryId = 4,

            };

        }
        public void SeedProductGender()
        {
            Men = new ProductGender()
            {
                Id = 1,
                GenderName = Enums.Gender.Men

            };

            Women = new ProductGender()
            {
                Id = 2,
                GenderName = Enums.Gender.Women


            };

            Kid = new ProductGender()
            {
                Id = 3,
                GenderName = Enums.Gender.Kid
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
