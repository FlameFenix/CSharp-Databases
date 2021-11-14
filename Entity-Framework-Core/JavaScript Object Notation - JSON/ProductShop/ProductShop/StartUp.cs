using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Dtos;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        private static MapperConfiguration configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ProductShopProfile>();
        });

        private static IMapper mapper = new Mapper(configuration);
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();

            //db.Database.EnsureDeleted();

            //db.Database.EnsureCreated();

            // 1.Import Users

            //string users = File.ReadAllText(@"../../../Datasets/users.json");

            //Console.WriteLine(ImportUsers(db, users));

            // 2.Import Products

            //string products = File.ReadAllText(@"../../../Datasets/products.json");

            //Console.WriteLine(ImportProducts(db, products));

            // 3.Import Categories

            //string categories = File.ReadAllText(@"../../../Datasets/categories.json");

            //Console.WriteLine(ImportCategories(db, categories));

            //  4.Import Categories and Products

            //string categoryProducts = File.ReadAllText(@"../../../Datasets/categories-products.json");

            //Console.WriteLine(ImportCategoryProducts(db, categoryProducts));

            // 5. Export Products In Range

            // Console.WriteLine(GetProductsInRange(db));

            // 6. Export Sold Products

            // Console.WriteLine(GetSoldProducts(db));

            // 7. Export Users and Products

            // Console.WriteLine(GetCategoriesByProductsCount(db));
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {

            ICollection<InputUsersDto> createdUsers = JsonConvert.DeserializeObject<List<InputUsersDto>>(inputJson);

            var users = context.Users;

            var mappedUsers = mapper.Map<ICollection<User>>(createdUsers);

            users.AddRange(mappedUsers);

            context.SaveChanges();

            return $"Successfully imported {createdUsers.Count}";

        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {

            ICollection<Product> productsJSON = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            var products = context.Products;

            products.AddRange(productsJSON);

            context.SaveChanges();

            return $"Successfully imported {productsJSON.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            ICollection<Category> categoriesJson = JsonConvert.DeserializeObject<List<Category>>(inputJson)
                .Where(x => x.Name != null).ToList();

            var categories = context.Categories;

            categories.AddRange(categoriesJson);

            context.SaveChanges();

            return $"Successfully imported {categoriesJson.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {

            ICollection<CategoryProduct> categoryProductsJson = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

            var categoryProducts = context.CategoryProducts;

            categoryProducts.AddRange(categoryProductsJson);

            context.SaveChanges();

            return $"Successfully imported {categoryProductsJson.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new
                {
                    name = x.Name,
                    price = x.Price,
                    seller = x.Seller.FirstName + ' ' + x.Seller.LastName,
                })
                .OrderBy(x => x.price)
                .ToList();

            string productsJson = JsonConvert.SerializeObject(products, Formatting.Indented);

            return productsJson;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var soldProducts = context.Users
                                      .Where(x => x.ProductsSold.Any(y => y.Buyer != null))
                                      .OrderBy(x => x.LastName)
                                      .ThenBy(x => x.FirstName)
                                      .Select(x => new
                                      {
                                          firstName = x.FirstName,
                                          lastName = x.LastName,
                                          soldProducts = x.ProductsSold.Select(p => new
                                          {
                                              name = p.Name,
                                              price = p.Price,
                                              buyerFirstName = p.Buyer.FirstName,
                                              buyerLastName = p.Buyer.LastName
                                          })
                                      })
                                      .ToList();

            string soldProductsJson = JsonConvert.SerializeObject(soldProducts, Formatting.Indented);

            return soldProductsJson;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories.Select(x => new
            {
                category = x.Name,
                productsCount = x.CategoryProducts.Count(),
                averagePrice = $"{x.CategoryProducts.Average(y => y.Product.Price):F2}",
                totalRevenue = $"{x.CategoryProducts.Sum(y => y.Product.Price):F2}"
            })
                .OrderByDescending(x => x.productsCount)
                .ToList();

            var categoriesJson = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return categoriesJson;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {

        }
    }
}