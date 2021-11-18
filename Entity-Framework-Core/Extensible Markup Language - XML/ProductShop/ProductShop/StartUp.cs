
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

            context.Database.EnsureDeleted();

            context.Database.EnsureCreated();

            // 01. Import Users

            string importUsers = File.ReadAllText("../../../Datasets/users.xml");

            Console.WriteLine(ImportUsers(context, importUsers));

            // 02. Import Products

            string importProducts = File.ReadAllText("../../../Datasets/products.xml");

            Console.WriteLine(ImportProducts(context, importProducts));

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
    }
}