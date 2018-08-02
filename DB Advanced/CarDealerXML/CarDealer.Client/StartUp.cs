namespace CarDealer.Client
{
    using AutoMapper;
    using CarDealer.Client.Dto;
    using CarDealer.Data;
    using CarDealer.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
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
            InsertParts(context, mapper);

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
