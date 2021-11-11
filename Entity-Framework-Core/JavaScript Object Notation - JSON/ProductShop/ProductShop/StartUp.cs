using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();

            /* WHEN CREATE DB YOU SHOULD USE string "path" */

            // 2. Import Users

            // string path = @"../../../Datasets/users.json";

            //Console.WriteLine(ImportUsers(db, path)); 

            // 3. Import Products

            //string path = @"../../../Datasets/products.json";

            //Console.WriteLine(ImportProducts(db, path));
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            
            //var jsonString = File.ReadAllText(inputJson);

            ICollection<User> createdUsers = JsonConvert.DeserializeObject<List<User>>(inputJson);

            var users = context.Users;

            foreach (var user in createdUsers)
            {
                users.Add(user);
            }

            context.SaveChanges();

            return $"Successfully imported {createdUsers.Count}";

        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            // string jsonString = File.ReadAllText(inputJson);

            ICollection<Product> productsJSON = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            var products = context.Products;

            foreach (var product in productsJSON)
            {
                products.Add(product);
            }

            context.SaveChanges();

            return $"Successfully imported {productsJSON.Count}";
        }
    }
}