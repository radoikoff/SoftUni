namespace CarDealer.Client
{
    using AutoMapper;
    using CarDealer.Client.Dto;
    using CarDealer.Client.Dto.Output;
    using CarDealer.Data;
    using CarDealer.Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using DA = System.ComponentModel.DataAnnotations;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>());
            var mapper = config.CreateMapper();

            var context = new CarDealerContext();

            //InsertSuppliers(context, mapper);
            //InsertParts(context, mapper);
            //InsertCars(context, mapper);
            //InsertCarParts(context, mapper);
            //InsertCustomers(context, mapper);
            //InsertSales(context, mapper);


            //GetCarsWithDistance(context);
            //GetCarsFromMakeFerrari(context);
            //GetLocalSuppliers(context);
            //GetCarsWithTheirListOfParts(context);
            //GetTotalSalesByCustomer(context);
            //GetSalesWithDiscount(context);



            //InsertSuppliersJson(context);
            //InsertPartsJson(context);
            //InsertCarsJson(context);
            //InsertCustomersJson(context);
            //InsertSales(context);

            //GetOrderedCustomersJson(context);
            //GetCarsFromMakeToyota(context);
            GetLocalSuppliersJson(context);
        }

        private static void GetLocalSuppliersJson(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                                   .Where(x => x.IsImporter == false)
                                   .Select(x => new
                                   {
                                       x.Id,
                                       x.Name,
                                       PartsCount = x.Parts.Count()
                                   })
                                   .ToArray();

            var json = JsonConvert.SerializeObject(suppliers, new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });

            File.WriteAllText("../../../Json/Output/local-suppliers.json", json);
        }

        private static void GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                              .Where(x => x.Make == "Toyota")
                              .OrderBy(x => x.Model)
                              .ThenByDescending(x => x.TravelledDistance)
                              .Select(x => new
                              {
                                  x.Id,
                                  x.Make,
                                  x.Model,
                                  x.TravelledDistance
                              })
                              .ToArray();

            var json = JsonConvert.SerializeObject(cars, new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });

            File.WriteAllText("../../../Json/Output/toyota-cars.json", json);
        }

        private static void GetOrderedCustomersJson(CarDealerContext context)
        {
            var customers = context.Customers
                                   .OrderBy(x => x.BirthDate)
                                   .ThenBy(x => x.IsYoungDriver)
                                   //.Select(x=> new
                                   //{
                                   //    Id = x.Id,
                                   //    Name = x.Name,
                                   //    BirthDate = x.BirthDate,
                                   //    IsYoungDriver = x.IsYoungDriver,
                                   //    Sales = x.Sales.ToArray() 
                                   //})
                                   .ToArray();

            var json = JsonConvert.SerializeObject(customers, new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });

            File.WriteAllText("../../../Json/Output/ordered-customers.json", json);
        }


        //Inserts JSON
        private static void InsertSales(CarDealerContext context)
        {
            var discountValues = new decimal[] { 0, 0.05m, 0.10m, 0.15m, 0.20m, 0.30m, 0.40m, 0.50m };

            List<Sale> sales = new List<Sale>();

            var random = new Random();

            for (int saleId = 0; saleId < 400; saleId++)
            {
                var carId = random.Next(1, 358);
                var customerId = random.Next(1, 31);
                var discount = discountValues.OrderBy(x => random.Next()).First();

                if (context.Customers.Find(customerId).IsYoungDriver)
                {
                    discount += 0.05m;
                }

                var sale = new Sale
                {
                    CarId = carId,
                    CustomerId = customerId,
                    Discount = discount
                };

                sales.Add(sale);
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();
        }

        private static void InsertCustomersJson(CarDealerContext context)
        {
            string jsonString = File.ReadAllText("../../../Json/customers.json");

            var deserializedCustomers = JsonConvert.DeserializeObject<Customer[]>(jsonString);

            var customers = new List<Customer>();

            foreach (var customer in deserializedCustomers)
            {
                if (IsValid(customer))
                {
                    customers.Add(customer);
                }
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();
        }

        private static void InsertCarsJson(CarDealerContext context)
        {
            string jsonString = File.ReadAllText("../../../Json/cars.json");

            var deserializedCars = JsonConvert.DeserializeObject<Car[]>(jsonString);

            var cars = new List<Car>();
            var parts = new List<PartCar>();

            foreach (var car in deserializedCars)
            {
                if (!IsValid(car))
                {
                    continue;
                }

                cars.Add(car);

                var numberOfParts = new Random().Next(10, 21);
                for (int i = 0; i < numberOfParts; i++)
                {
                    int partId = new Random().Next(1, 131);

                    while (car.PartCars.Any(x => x.PartId == partId))
                    {
                        partId = new Random().Next(1, 131);
                    }

                    car.PartCars.Add(new PartCar { PartId = partId });
                }
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();
        }

        private static void InsertPartsJson(CarDealerContext context)
        {
            string jsonString = File.ReadAllText("../../../Json/parts.json");

            var deserializedParts = JsonConvert.DeserializeObject<Part[]>(jsonString);

            var parts = new List<Part>();

            foreach (var part in deserializedParts)
            {
                if (IsValid(part))
                {
                    part.SupplierId = new Random().Next(1, 32);
                    parts.Add(part);
                }
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();
        }

        private static void InsertSuppliersJson(CarDealerContext context)
        {
            string jsonString = File.ReadAllText("../../../Json/suppliers.json");

            var deserializedSuppliers = JsonConvert.DeserializeObject<Supplier[]>(jsonString);

            var suppliers = new List<Supplier>();

            foreach (var supplier in deserializedSuppliers)
            {
                if (IsValid(supplier))
                {
                    suppliers.Add(supplier);
                }
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
        }


        //Queries XML
        private static void GetSalesWithDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                               .Select(s => new SaleOutDto
                               {
                                   CarData = new CarOutTwoDto
                                   {
                                       Make = s.Car.Make,
                                       Model = s.Car.Model,
                                       TravelledDistance = s.Car.TravelledDistance
                                   },

                                   CustomerName = s.Customer.Name,
                                   Discount = s.Discount,
                                   Price = s.Car.PartCars.Sum(pc => pc.Part.Price),
                                   PriceWithDiscount = (s.Car.PartCars.Sum(pc => pc.Part.Price)) * (1 - s.Discount)
                               })
                               .ToArray();

            var sb = new StringBuilder();
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var serializer = new XmlSerializer(typeof(SaleOutDto[]), new XmlRootAttribute("sales"));
            serializer.Serialize(new StringWriter(sb), sales, xmlNamespaces);

            File.WriteAllText("../../../Xml/Output/sales-discounts.xml", sb.ToString());
        }

        private static void GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                                   .Where(c => c.Sales.Count >= 1)
                                   .Select(c => new CustomerWithCarsOutDto
                                   {
                                       FullName = c.Name,
                                       BoughtCars = c.Sales.Count,
                                       SpentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(p => p.Part.Price))
                                   })
                                   .OrderByDescending(x => x.SpentMoney)
                                   .ThenByDescending(x => x.BoughtCars)
                                   .ToArray();

            var sb = new StringBuilder();
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var serializer = new XmlSerializer(typeof(CustomerWithCarsOutDto[]), new XmlRootAttribute("customers"));
            serializer.Serialize(new StringWriter(sb), customers, xmlNamespaces);

            File.WriteAllText("../../../Xml/Output/customers-total-sales.xml", sb.ToString());
        }

        private static void GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                              .Select(c => new CarOutDto
                              {
                                  Make = c.Make,
                                  Model = c.Model,
                                  TravelledDistance = c.TravelledDistance,
                                  Parts = c.PartCars.Select(p => new PartOutDto
                                  {
                                      Name = p.Part.Name,
                                      Price = p.Part.Price
                                  })
                                  .ToArray()
                              })
                              .ToArray();

            var sb = new StringBuilder();
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var serializer = new XmlSerializer(typeof(CarOutDto[]), new XmlRootAttribute("cars"));
            serializer.Serialize(new StringWriter(sb), cars, xmlNamespaces);

            File.WriteAllText("../../../Xml/Output/cars-and-parts.xml", sb.ToString());

        }

        private static void GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                                   .Where(s => s.IsImporter == false)
                                   .Select(s => new LocalSuppliersOutDto
                                   {
                                       Id = s.Id,
                                       Name = s.Name,
                                       PartsCount = s.Parts.Count
                                   })
                                   .ToArray();

            var sb = new StringBuilder();
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var serializer = new XmlSerializer(typeof(LocalSuppliersOutDto[]), new XmlRootAttribute("suppliers"));
            serializer.Serialize(new StringWriter(sb), suppliers, xmlNamespaces);

            File.WriteAllText("../../../Xml/Output/local-suppliers.xml", sb.ToString());
        }

        private static void GetCarsFromMakeFerrari(CarDealerContext context)
        {
            var cars = context.Cars
                              .Where(c => c.Make == "Ferrari")
                              .OrderBy(c => c.Model)
                              .ThenByDescending(c => c.TravelledDistance)
                              .Select(c => new FerrariCarOutDto
                              {
                                  Id = c.Id,
                                  Model = c.Model,
                                  TravelledDistance = c.TravelledDistance
                              })
                              .ToArray();

            var sb = new StringBuilder();
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var serializer = new XmlSerializer(typeof(FerrariCarOutDto[]), new XmlRootAttribute("cars"));
            serializer.Serialize(new StringWriter(sb), cars, xmlNamespaces);

            File.WriteAllText("../../../Xml/Output/ferrari-cars.xml", sb.ToString());
        }

        private static void GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                              .Where(c => c.TravelledDistance > 2000000)
                              .OrderBy(c => c.Make)
                              .ThenBy(c => c.Model)
                              .Select(c => new CarDto
                              {
                                  Make = c.Make,
                                  Model = c.Model,
                                  TravelledDistance = c.TravelledDistance
                              })
                              .ToArray();

            var sb = new StringBuilder();
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var serializer = new XmlSerializer(typeof(CarDto[]), new XmlRootAttribute("cars"));
            serializer.Serialize(new StringWriter(sb), cars, xmlNamespaces);

            File.WriteAllText("../../../Xml/Output/cars.xml", sb.ToString());
        }

        //Inserts XML

        private static void InsertSales(CarDealerContext context, IMapper mapper)
        {
            var discountValues = new decimal[] { 0, 0.05m, 0.10m, 0.15m, 0.20m, 0.30m, 0.40m, 0.50m };

            List<Sale> sales = new List<Sale>();

            var random = new Random();

            for (int carId = 1; carId < 327; carId++)
            {
                var sale = new Sale
                {
                    CarId = carId,
                    CustomerId = random.Next(1, 30),
                    Discount = discountValues.OrderBy(x => random.Next()).First()
                };

                sales.Add(sale);
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();
        }

        private static void InsertCustomers(CarDealerContext context, IMapper mapper)
        {
            var xmlString = File.ReadAllText("../../../Xml/customers.xml");

            var serializer = new XmlSerializer(typeof(CustomerDto[]), new XmlRootAttribute("customers"));
            var deserializedCustomers = (CustomerDto[])serializer.Deserialize(new StringReader(xmlString));

            List<Customer> customers = new List<Customer>();

            foreach (var customerDto in deserializedCustomers)
            {
                if (!IsValid(customerDto))
                {
                    continue;
                }
                var customer = mapper.Map<Customer>(customerDto);

                customers.Add(customer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();
        }

        private static void InsertCarParts(CarDealerContext context, IMapper mapper)
        {
            List<PartCar> parts = new List<PartCar>();
            for (int carId = 1; carId < 328; carId++)
            {
                var numberOfParts = new Random().Next(10, 21);
                for (int i = 0; i < numberOfParts; i++)
                {
                    var random = new Random();

                    int partId = new Random().Next(1, 131);

                    while (parts.Any(x => x.CarId == carId && x.PartId == partId))
                    {
                        partId = random.Next(1, 131);
                    }

                    var partCar = new PartCar
                    {
                        CarId = carId,
                        PartId = partId
                    };

                    parts.Add(partCar);
                }
            }


            context.PartCars.AddRange(parts);
            context.SaveChanges();
        }

        private static void InsertCars(CarDealerContext context, IMapper mapper)
        {
            var xmlString = File.ReadAllText("../../../Xml/cars.xml");

            var serializer = new XmlSerializer(typeof(CarDto[]), new XmlRootAttribute("cars"));
            var deserializedCars = (CarDto[])serializer.Deserialize(new StringReader(xmlString));

            List<Car> cars = new List<Car>();

            foreach (var carDto in deserializedCars)
            {
                if (!IsValid(carDto))
                {
                    continue;
                }
                var car = mapper.Map<Car>(carDto);

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();
        }

        private static void InsertParts(CarDealerContext context, IMapper mapper)
        {
            var xmlString = File.ReadAllText("../../../Xml/parts.xml");

            var serializer = new XmlSerializer(typeof(PartDto[]), new XmlRootAttribute("parts"));
            var deserializedParts = (PartDto[])serializer.Deserialize(new StringReader(xmlString));

            List<Part> parts = new List<Part>();
            foreach (var partDto in deserializedParts)
            {
                if (!IsValid(partDto))
                {
                    continue;
                }
                var part = mapper.Map<Part>(partDto);

                part.SupplierId = new Random().Next(1, 32);
                parts.Add(part);
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();
        }

        private static void InsertSuppliers(CarDealerContext context, IMapper mapper)
        {
            var xmlString = File.ReadAllText("../../../Xml/suppliers.xml");

            var serializer = new XmlSerializer(typeof(SupplierDto[]), new XmlRootAttribute("suppliers"));
            var deserializedSuppliers = (SupplierDto[])serializer.Deserialize(new StringReader(xmlString));

            List<Supplier> suppliers = new List<Supplier>();
            foreach (var supplierDto in deserializedSuppliers)
            {
                if (!IsValid(supplierDto))
                {
                    continue;
                }
                var supplier = mapper.Map<Supplier>(supplierDto);
                suppliers.Add(supplier);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
        }


        private static bool IsValid(object obj)
        {
            var validationContext = new DA.ValidationContext(obj);
            var results = new List<DA.ValidationResult>();
            return DA.Validator.TryValidateObject(obj, validationContext, results, true);
        }
    }
}
