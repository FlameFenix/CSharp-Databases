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

            // db.Database.EnsureDeleted();

            // db.Database.EnsureCreated();

            // 2.Import Users

            // string path2 = @"../../../Datasets/users.json";

            // Console.WriteLine(ImportUsers(db, path2));

            // 3.Import Products

            // string path3 = @"../../../Datasets/products.json";

            // Console.WriteLine(ImportProducts(db, path3));

            // 4.Import Categories

            // string path4 = @"../../../Datasets/categories.json";

            // Console.WriteLine(ImportCategories(db, path4));

            // 5. Import Categories and Products

             //string path5 = @"../../../Datasets/categories-products.json";

             //Console.WriteLine(ImportCategoryProducts(db, path5));
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            
            // var jsonString = File.ReadAllText(inputJson);

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

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            // string jsonString = File.ReadAllText(inputJson);

            ICollection<Category> categoriesJson = JsonConvert.DeserializeObject<List<Category>>(inputJson)
                .Where(x => x.Name != null).ToList();

            var categories = context.Categories;

            foreach (var category in categoriesJson)
            {
                categories.Add(category);
            }

            context.SaveChanges();

            return $"Successfully imported {categoriesJson.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            // string jsonString = File.ReadAllText(inputJson);

            ICollection<CategoryProduct> categoryProductsJson = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

            var categoryProducts = context.CategoryProducts;

            foreach (var categoryProduct in categoryProductsJson)
            {
                    categoryProducts.Add(categoryProduct);
            }

            context.SaveChanges();

            return $"Successfully imported {categoryProductsJson.Count}";
        }
    }
}