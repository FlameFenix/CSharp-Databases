using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.Datasets;
using CarDealer.DTO;
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

            Console.WriteLine(ImportParts(context, inputParts));

            // 10. Import Cars

            var inputCars = File.ReadAllText(@"../../../Datasets/cars.json");
           
            Console.WriteLine(ImportCars(context, inputCars));

            // 11. Import Customers

            var inputCustomers = File.ReadAllText(@"../../../Datasets/customers.json");

            Console.WriteLine(ImportCustomers(context, inputCustomers));

            // 12. Import Sales

            var inputSales = File.ReadAllText(@"../../../Datasets/sales.json");

            Console.WriteLine(ImportSales(context, inputSales));
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

            var carsJson = JsonConvert.DeserializeObject<IEnumerable<InputCarsDto>>(inputJson);

            foreach (var car in carsJson)
            {
                Car currentCar = new Car()
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance,
                };

                foreach (var carPart in car.partsId.Distinct())
                {
                    Part partCar = context.Parts.FirstOrDefault(x => x.Id == carPart);

                    if(partCar == null)
                    {
                        continue;
                    }

                    currentCar.PartCars.Add(new PartCar()
                    {
                        Part = partCar
                    });
                }

                cars.Add(currentCar);
            }

            context.SaveChanges();

            return $"Successfully imported {context.Cars.Count()}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = context.Customers;

            var customersJson = JsonConvert.DeserializeObject<IEnumerable<Customer>>(inputJson);

            customers.AddRange(customersJson);

            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = context.Sales;

            var salesJson = JsonConvert.DeserializeObject<IEnumerable<Sale>>(inputJson);

            sales.AddRange(salesJson);

            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }
    }
}