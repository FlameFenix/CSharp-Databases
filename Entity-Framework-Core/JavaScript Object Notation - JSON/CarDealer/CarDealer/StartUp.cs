using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.Datasets;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        private static MapperConfiguration configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarDealerProfile>();
        });

        private static IMapper mapper = new Mapper(configuration);
        public static void Main(string[] args)
        {
            DbContextOptionsBuilder options = new DbContextOptionsBuilder();

            options.UseSqlServer("Server=.;Database=CarDealer;Trusted_Connection=True;");

            var context = new CarDealerContext(options.Options);

            context.Database.EnsureDeleted();

            context.Database.EnsureCreated();

            // 8. Import Suppliers

            var inputSuppliers = File.ReadAllText(@"../../../Datasets/suppliers.json");

            Console.WriteLine(ImportSuppliers(context, inputSuppliers));

            // 9. Import Parts

            var inputParts = File.ReadAllText(@"../../../Datasets/parts.json");

            Console.WriteLine(ImportSuppliers(context, inputParts));

            // 10. Import Cars

            var inputCars = File.ReadAllText(@"../../../Datasets/cars.json");

            Console.WriteLine(ImportCars(context, inputCars));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = context.Suppliers;

            IEnumerable<Supplier> suppliersJson = JsonConvert.DeserializeObject<IEnumerable <Supplier>>(inputJson);

            suppliers.AddRange(suppliersJson);

            context.SaveChanges();

            return $"Successfully imported {suppliersJson.Count()}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = context.Parts;

            var suppliers = context.Suppliers.Select(x => x.Id).ToList();

            IEnumerable<Part> partsJson = JsonConvert.DeserializeObject<IEnumerable<Part>>(inputJson)
                                                     .Where(x => suppliers.Contains(x.SupplierId));

            parts.AddRange(partsJson);

            context.SaveChanges();

            return $"Successfully imported {partsJson.Count()}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var cars = context.Cars;

            return $"Successfully imported {context.Cars.Count()}.";
        }
    }
}