namespace CarDealer.Client
{
    using AutoMapper;
    using CarDealer.Client.Dto;
    using CarDealer.Client.Dto.Output;
    using CarDealer.Data;
    using CarDealer.Models;
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
            GetTotalSalesByCustomer(context);
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

        //Inserts

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
