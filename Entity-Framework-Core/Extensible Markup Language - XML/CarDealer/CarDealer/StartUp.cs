using CarDealer.Data;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();

            //context.Database.EnsureDeleted();

            //context.Database.EnsureCreated();

            //// 09. Import Suppliers

            //string inputSuppliers = File.ReadAllText("../../../Datasets/suppliers.xml");
            //Console.WriteLine(ImportSuppliers(context, inputSuppliers));

            //// 10. Import Parts

            //string inputParts = File.ReadAllText("../../../Datasets/parts.xml");
            //Console.WriteLine(ImportParts(context, inputParts));

            //// 11. Import Cars

            //string inputCars = File.ReadAllText("../../../Datasets/cars.xml");
            //Console.WriteLine(ImportCars(context, inputCars));

            //// 12. Import Customers

            //string inputCustomers = File.ReadAllText("../../../Datasets/customers.xml");
            //Console.WriteLine(ImportCustomers(context, inputCustomers));

            //// 13. Import Sales

            //string inputSales = File.ReadAllText("../../../Datasets/sales.xml");
            //Console.WriteLine(ImportSales(context, inputSales));

            // 14. Cars With Distance

            // Console.WriteLine(GetCarsWithDistance(context));

            // 15. Cars from make BMW

            // Console.WriteLine(GetCarsFromMakeBmw(context));

            // 16. Local Suppliers

            Console.WriteLine(GetLocalSuppliers(context));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var serializer = GenerateSerializer(typeof(ImportSuppliersDto[]), "Suppliers");

            var reader = new StringReader(inputXml);

            var suppliers = new HashSet<Supplier>();

            using (reader)
            {
                var dtos = (ImportSuppliersDto[])serializer.Deserialize(reader);

                foreach (var dto in dtos)
                {
                    Supplier supplier = new Supplier()
                    {
                        Name = dto.Name,
                        IsImporter = bool.Parse(dto.IsImporter)
                    };

                    if (supplier != null)
                    {
                        suppliers.Add(supplier);
                    }
                }
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {context.Suppliers.Count()}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = GenerateSerializer(typeof(ImportPartsDto[]), "Parts");

            StringReader stringReader = new StringReader(inputXml);

            var parts = new HashSet<Part>();

            using (stringReader)
            {
                var dtos = (ImportPartsDto[])serializer.Deserialize(stringReader);

                foreach (var dto in dtos)
                {
                    Supplier supplier = context.Suppliers.FirstOrDefault(x => x.Id == int.Parse(dto.SupplierId));

                    if (supplier == null)
                    {
                        continue;
                    }

                    Part part = new Part()
                    {
                        Name = dto.Name,
                        Price = decimal.Parse(dto.Price, CultureInfo.InvariantCulture),
                        Quantity = int.Parse(dto.Quantity),
                        SupplierId = int.Parse(dto.SupplierId)
                    };

                    parts.Add(part);
                }
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {context.Parts.Count()}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = GenerateSerializer(typeof(ImportCarsDto[]), "Cars");

            StringReader reader = new StringReader(inputXml);

            var cars = new HashSet<Car>();

            using (reader)
            {
                var dtos = (ImportCarsDto[])serializer.Deserialize(reader);

                foreach (var dto in dtos)
                {
                    Car car = new Car()
                    {
                        Make = dto.Make,
                        Model = dto.Model,
                        TravelledDistance = long.Parse(dto.TraveledDistance)
                    };

                    foreach (var partId in dto.Parts.Select(x => x.Id).Distinct())
                    {
                        var carPart = context.Parts.FirstOrDefault(x => x.Id == partId);

                        if (carPart == null)
                        {
                            continue;
                        }

                        car.PartCars.Add(new PartCar()
                        {
                            Car = car,
                            CarId = car.Id,
                            Part = carPart,
                            PartId = carPart.Id
                        });
                    }

                    cars.Add(car);
                }
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {context.Cars.Count()}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = GenerateSerializer(typeof(ImportCustomersDto[]), "Customers");

            StringReader reader = new StringReader(inputXml);

            var customers = new HashSet<Customer>();

            using (reader)
            {
                var dtos = (ImportCustomersDto[])serializer.Deserialize(reader);

                foreach (var dto in dtos)
                {
                    Customer customer = new Customer()
                    {
                        Name = dto.Name,
                        BirthDate = DateTime.Parse(dto.BirthDate),
                        IsYoungDriver = bool.Parse(dto.IsYoungDriver)
                    };

                    customers.Add(customer);
                }
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {context.Customers.Count()}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = GenerateSerializer(typeof(ImportSalesDto[]), "Sales");

            StringReader reader = new StringReader(inputXml);

            var sales = new HashSet<Sale>();

            using (reader)
            {
                var dtos = (ImportSalesDto[])serializer.Deserialize(reader);

                foreach (var dto in dtos)
                {
                    Car car = context.Cars.FirstOrDefault(x => x.Id == int.Parse(dto.CarId));

                    if (car == null)
                    {
                        continue;
                    }

                    Sale sale = new Sale()
                    {
                        CarId = car.Id,
                        CustomerId = int.Parse(dto.CustomerId),
                        Discount = decimal.Parse(dto.Discount)

                    };

                    sales.Add(sale);
                }
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {context.Sales.Count()}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var serializer = GenerateSerializer(typeof(CarsWithDistanceDto[]), "cars");

            var namespaces = new XmlSerializerNamespaces();

            namespaces.Add(string.Empty, string.Empty);

            var sb = new StringBuilder();

            var sw = new StringWriter(sb);

            var dtos = context.Cars
                .Where(x => x.TravelledDistance > 2000000)
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .Select(x => new CarsWithDistanceDto
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance.ToString()
                })
                .ToArray();

            serializer.Serialize(sw, dtos, namespaces);

            return sb.ToString().Trim();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var serializer = GenerateSerializer(typeof(ExportCarsFromMakeBmwDto[]), "cars");

            var namespaces = new XmlSerializerNamespaces();

            namespaces.Add(string.Empty, string.Empty);

            var sb = new StringBuilder();

            var sw = new StringWriter(sb);

            var dtos = context.Cars
                .Where(x => x.Make == "BMW")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .Select(x => new ExportCarsFromMakeBmwDto()
                {
                    Id = x.Id.ToString(),
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance.ToString()
                })
                .ToArray();

            serializer.Serialize(sw, dtos, namespaces);

            return sb.ToString().Trim();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var serializer = GenerateSerializer(typeof(ExportLocalSuppliersDto[]), "suppliers");

            var namespaces = new XmlSerializerNamespaces();

            namespaces.Add(string.Empty, string.Empty);

            var sb = new StringBuilder();

            var sw = new StringWriter(sb);

            var dtos = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new ExportLocalSuppliersDto()
                {
                    Id =x.Id.ToString(),
                    Name = x.Name,
                    PartsCount = x.Parts.Count().ToString()
                })
                .ToArray();

            serializer.Serialize(sw, dtos, namespaces);

            return sb.ToString().Trim();
        }

        public static XmlSerializer GenerateSerializer(Type type, string root)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(root);
            XmlSerializer serializer = new XmlSerializer(type, xmlRoot);

            return serializer;
        }
    }
}