
using System;
using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using System.Globalization;
using ProductShop.Dtos.Export;
using System.Text;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();

            //context.Database.EnsureDeleted();

            //context.Database.EnsureCreated();

            // 01.Import Users

            //string importUsers = File.ReadAllText("../../../Datasets/users.xml");

            //Console.WriteLine(ImportUsers(context, importUsers));

            // 02.Import Products

            //string importProducts = File.ReadAllText("../../../Datasets/products.xml");

            //Console.WriteLine(ImportProducts(context, importProducts));

            // 03. Import Categories

            //string importCategories = File.ReadAllText("../../../Datasets/categories.xml");

            //Console.WriteLine(ImportCategories(context, importCategories));

            // 04. Import CategoryProducts

            //string importCategoryProducts = File.ReadAllText("../../../Datasets/categories-products.xml");

            //Console.WriteLine(ImportCategoryProducts(context, importCategoryProducts));

            // 05. Products In Range

            // Console.WriteLine(GetProductsInRange(context));

            // 06. Sold Products

            // Console.WriteLine(GetSoldProducts(context));

            // 07. Categories By Products Count

            // Console.WriteLine(GetCategoriesByProductsCount(context));

            // 08. Users and Products
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = GenerateSerializer(typeof(ImportUsersDto[]), "Users");

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
            XmlSerializer serializer = GenerateSerializer(typeof(ImportProductsDto[]), "Products");

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
            XmlSerializer serializer = GenerateSerializer(typeof(ImportCategoriesDto[]), "Categories");

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
            var serializer = GenerateSerializer(typeof(ImportCategoryProductsDto[]), "CategoryProducts");

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
            XmlSerializer serializer = GenerateSerializer(typeof(ProductsInRangeDto[]), "Products");

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();

            namespaces.Add(String.Empty, String.Empty);

            StringBuilder sb = new StringBuilder();

            StringWriter sw = new StringWriter(sb);

            var dtos = context.Products.
                Where(x => x.Price >= 500 & x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Take(10)
                .Select(x => new ProductsInRangeDto()
                {
                    Name = x.Name,
                    Price = x.Price.ToString(),
                    BuyerName = x.Buyer.FirstName + " " + x.Buyer.LastName
                })
                .ToArray();

            serializer.Serialize(sw, dtos, namespaces);

            return sb.ToString().Trim();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {

            XmlSerializer serializer = GenerateSerializer(typeof(GetSoldProductsDto[]), "Users");

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();

            namespaces.Add(String.Empty, String.Empty);

            StringBuilder sb = new StringBuilder();

            StringWriter sw = new StringWriter(sb);

            var dtos = context.Users
                .Where(x => x.ProductsSold.Any())
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .Select(x => new GetSoldProductsDto()
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Products = x.ProductsSold.Select(y => new ProductDto()
                {
                    Name=y.Name,
                    Price=y.Price.ToString(),
                })
                .ToArray()
            })
                .ToArray();

            serializer.Serialize(sw, dtos, namespaces);

            return sb.ToString().Trim();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            XmlSerializer serializer = GenerateSerializer(typeof(CategoriesByProductsCountDto[]), "Categories");

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();

            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();

            StringWriter sw = new StringWriter(sb);

            var dtos = context.Categories
                .Select(x => new CategoriesByProductsCountDto()
                {
                    Name = x.Name,
                    Count = x.CategoryProducts.Count().ToString(),
                    averagePrice = x.CategoryProducts.Average(y => y.Product.Price).ToString(),
                    TotalRevenue = x.CategoryProducts.Sum(y => y.Product.Price).ToString()
                })
                .OrderByDescending(x => int.Parse(x.Count))
                .ThenBy(x => decimal.Parse(x.TotalRevenue))
                .ToArray();

            serializer.Serialize(sw, dtos, namespaces);

            return sb.ToString().Trim();
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            XmlSerializer serializer = GenerateSerializer(typeof(), "Users");

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();

            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();

            StringWriter sw = new StringWriter(sb);
        }

        public static XmlSerializer GenerateSerializer(Type type, string root)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(root);
            XmlSerializer serializer = new XmlSerializer(type, xmlRoot);
            return serializer;
        }

    }
}