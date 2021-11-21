﻿
using System;
using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using System.Globalization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();

            //context.Database.EnsureDeleted();

            //context.Database.EnsureCreated();

            // 01. Import Users

            //string importUsers = File.ReadAllText("../../../Datasets/users.xml");

            //Console.WriteLine(ImportUsers(context, importUsers));

            // 02. Import Products

            //string importProducts = File.ReadAllText("../../../Datasets/products.xml");

            //Console.WriteLine(ImportProducts(context, importProducts));

            // 03. Import Categories

            //string importCategories = File.ReadAllText("../../../Datasets/categories.xml");

            //Console.WriteLine(ImportCategories(context, importCategories));

            // 04. Import CategoryProducts

            //string importCategoryProducts = File.ReadAllText("../../../Datasets/categories-products.xml");

            //Console.WriteLine(ImportCategoryProducts(context, importCategoryProducts));


        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Users");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportUsersDto[]), xmlRoot);

            StringReader reader = new StringReader(inputXml);

            var dtos = xmlSerializer.Deserialize(reader) as ImportUsersDto[];

            ICollection<User> users = new HashSet<User>();

            foreach (var user in dtos)
            {
                User currentUser = new User()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Age = int.Parse(user.Age)
                };

                users.Add(currentUser);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {context.Users.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Products");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportProductsDto[]), xmlRoot);

            var reader = new StringReader(inputXml);

            var dtos = serializer.Deserialize(reader) as ImportProductsDto[];

            ICollection<Product> products = new HashSet<Product>();

            foreach (var product in dtos)
            {
                var currentProduct = new Product()
                {
                    Name = product.Name,
                    Price = decimal.Parse(product.Price, CultureInfo.InvariantCulture),
                    SellerId = int.Parse(product.SellerId),
                };
                if (product.buyerId != null)
                {
                    currentProduct.BuyerId = int.Parse(product.buyerId);
                }

                products.Add(currentProduct);
            }
            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {context.Products.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Categories");

            XmlSerializer serializer = new XmlSerializer(typeof(ImportCategoriesDto[]), xmlRoot);

            var reader = new StringReader(inputXml);

            var dtos = (ImportCategoriesDto[])serializer.Deserialize(reader);

            var categories = new List<Category>();

            foreach (var category in dtos)
            {
                Category currentCategory = new Category();

                if (string.IsNullOrEmpty(category.Name))
                {
                    continue;
                }
                currentCategory.Name = category.Name;

                categories.Add(currentCategory);
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {context.Categories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var xmlRoot = new XmlRootAttribute("CategoryProducts");

            var serializer = new XmlSerializer(typeof(ImportCategoryProductsDto[]), xmlRoot);

            StringReader reader = new StringReader(inputXml);

            var dtos = (ImportCategoryProductsDto[]) serializer.Deserialize(reader);

            foreach (var dto in dtos)
            {
                CategoryProduct currentCatProd = new CategoryProduct();

                var product = context.Products.FirstOrDefault(x => x.Id == int.Parse(dto.ProductId));

                var category = context.Categories.FirstOrDefault(x => x.Id == int.Parse(dto.CategoryId));

                if (product == null || category == null)
                {
                    continue;
                }

                currentCatProd = new CategoryProduct()
                {
                    Category = category,
                    CategoryId = category.Id,
                    Product = product,
                    ProductId = product.Id
                };

                context.CategoryProducts.Add(currentCatProd);
            }

            context.SaveChanges();

            return $"Successfully imported {context.CategoryProducts.Count()}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            return "";
        }
    }
}