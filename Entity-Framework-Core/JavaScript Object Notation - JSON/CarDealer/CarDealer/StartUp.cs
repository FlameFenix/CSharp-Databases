using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.Datasets;
using CarDealer.DTO;
using CarDealer.DTO.ExportDto;
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

            //context.Database.EnsureDeleted();

            //context.Database.EnsureCreated();

            // 8. Import Suppliers

            //var inputSuppliers = File.ReadAllText(@"../../../Datasets/suppliers.json");

            //Console.WriteLine(ImportSuppliers(context, inputSuppliers));

            // 9. Import Parts

            //var inputParts = File.ReadAllText(@"../../../Datasets/parts.json");

            //Console.WriteLine(ImportParts(context, inputParts));

            // 10. Import Cars

            //var inputCars = File.ReadAllText(@"../../../Datasets/cars.json");

            //Console.WriteLine(ImportCars(context, inputCars));

            // 11. Import Customers

            //var inputCustomers = File.ReadAllText(@"../../../Datasets/customers.json");

            //Console.WriteLine(ImportCustomers(context, inputCustomers));

            // 12. Import Sales

            //var inputSales = File.ReadAllText(@"../../../Datasets/sales.json");

            //Console.WriteLine(ImportSales(context, inputSales));

            // 13. Export Ordered Customers

            // Console.WriteLine(GetOrderedCustomers(context));

            // 14. Export Cars from Make Toyota

            // Console.WriteLine(GetCarsFromMakeToyota(context));

            // 15. Export Local Suppliers

            // Console.WriteLine(GetLocalSuppliers(context));

            // 16. Export Cars with Their List of Parts

            // Console.WriteLine(GetCarsWithTheirListOfParts(context));

            // 17. Export Total Sales by Customer

            // Console.WriteLine(GetTotalSalesByCustomer(context));

            // 18. Export Sales with Applied Discount

            Console.WriteLine(GetSalesWithAppliedDiscount(context));
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

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .Select(x => new OrderedCustomersDto()
                {
                    Name = x.Name,
                    BirthDate = x.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    IsYoungDriver = x.IsYoungDriver
                })
                .ToArray();

            var customersJson = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return customersJson;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.Make == "Toyota")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .Select(x => new CarByMakeToyotaDto()
                {
                    Id = x.Id,
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .ToArray();

            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => !x.IsImporter)
                .Select(x => new LocalSupliersDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count()
                });

            return JsonConvert.SerializeObject(suppliers, Formatting.Indented);
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(x => new CarWithListOfPartsDto()
                { 
                    car = new CarDto
                    {
                        Make = x.Make,
                        Model = x.Model,
                        TravelledDistance = x.TravelledDistance,
                    },
                    
                    parts = x.PartCars.Select(p => new PartDto
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price.ToString("f2")
                    })
                });

            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers.Where(x => x.Sales.Count() != 0).Select(x => new
            {
                fullName = x.Name,
                boughtCars = x.Sales.Count(),
                spentMoney = x.Sales.Sum(p => p.Car.PartCars.Sum(y => y.Part.Price))
            }).OrderByDescending(x => x.spentMoney).ThenByDescending(x => x.boughtCars);

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(x => new
            {
                car = new
                {
                    Make = x.Car.Make,
                    Model = x.Car.Model,
                    TravelledDistance = x.Car.TravelledDistance
                },

                customerName = x.Customer.Name,
                Discount = x.Discount.ToString("f2"),
                price = (x.Car.PartCars.Sum(p => p.Part.Price)).ToString("f2"),
                priceWithDiscount = (x.Car.PartCars.Sum(p => p.Part.Price) - x.Car.PartCars.Sum(p => p.Part.Price) * (x.Discount / 100)).ToString("f2")

            })
                .Take(10);

            return JsonConvert.SerializeObject(sales, Formatting.Indented);
        }
    }
}