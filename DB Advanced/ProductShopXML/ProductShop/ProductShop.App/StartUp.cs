namespace ProductShop.App
{
    using AutoMapper;
    using ProductShop.App.Dto;
    using ProductShop.Models;
    using System;
    using System.Collections.Generic;
    using DA = System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Xml.Serialization;
    using ProductShop.Data;
    using System.Linq;
    using ProductShop.App.Dto.Output;
    using System.Text;
    using System.Xml;
    using Newtonsoft.Json;

    public class StartUp
    {
        public static void Main()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<ProductShopProfile>());
            var mapper = config.CreateMapper();

            var context = new ProductShopContext();

            #region XML data inserts and queries

            //InsertUsersFromXml(context, mapper);
            //InsertProductsFromXml(context, mapper);
            //InsertCategoriesFromXml(context, mapper);
            //InsertProductCategoriesFromXml(context, mapper);


            //GetProductsInRange(context);
            //GetSoldProducts(context);
            //GetCategoriesByProductsCount(context);
            //GetUsersAndProducts(context);

            #endregion

            //InsertUsersFromJson(context);
            //InsertProductsFromJson(context);
            //InsertCategoriesFromJson(context);
            //InsertProductCategoriesFromJson(context);

        }


        //JSON Inserts

        private static void InsertProductCategoriesFromJson(ProductShopContext context)
        {
            var categoryProducts = new List<CategoryProduct>();

            for (int productId = 1; productId <= 200; productId++)
            {
                var categoryId = new Random().Next(1, 12);

                var categoryProduct = new CategoryProduct
                {
                    CategoryId = categoryId,
                    ProductId = productId
                };

                categoryProducts.Add(categoryProduct);
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();
        }

        private static void InsertCategoriesFromJson(ProductShopContext context)
        {
            string jsonString = File.ReadAllText("../../../Json/categories.json");

            var deserializedCategories = JsonConvert.DeserializeObject<Category[]>(jsonString);

            var categories = new List<Category>();

            foreach (var category in deserializedCategories)
            {
                if (IsValid(category))
                {
                    categories.Add(category);
                }
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();
        }

        private static void InsertProductsFromJson(ProductShopContext context)
        {
            string jsonString = File.ReadAllText("../../../Json/products.json");

            var deserializedProducts = JsonConvert.DeserializeObject<Product[]>(jsonString);

            var products = new List<Product>();

            foreach (var product in deserializedProducts)
            {
                if (!IsValid(product))
                {
                    continue;
                }

                var sellerId = new Random().Next(1, 35);
                var buyerId = new Random().Next(35, 57);

                var random = new Random().Next(1, 5);

                product.SellerId = sellerId;
                product.BuyerId = buyerId;

                if (random == 4)
                {
                    product.BuyerId = null;
                }

                products.Add(product);
            }

            context.Products.AddRange(products);
            context.SaveChanges();
        }

        private static void InsertUsersFromJson(ProductShopContext context)
        {
            string jsonString = File.ReadAllText("../../../Json/users.json");

            var deserializedUsers = JsonConvert.DeserializeObject<User[]>(jsonString);

            var users = new List<User>();

            foreach (var user in deserializedUsers)
            {
                if (IsValid(user))
                {
                    users.Add(user);
                }
            }

            context.Users.AddRange(users);
            context.SaveChanges();
        }


        //XML Queries

        private static void GetUsersAndProducts(ProductShopContext context)
        {
            var users = new UsersOutDto
            {
                Count = context.Users.Count(),
                Users = context.Users
                 .Where(u => u.ProdcutsSold.Count >= 1)
                 .Select(u => new UsersUserOutDto
                 {
                     FirstName = u.FirstName,
                     LastName = u.LastName,
                     Age = u.Age.ToString(),
                     SoldProducts = new UserSoldProductsOutDto
                     {
                         Count = u.ProdcutsSold.Count(),
                         Products = u.ProdcutsSold.Select(x => new UserSoldProductsProductOutDto
                         {
                             Name = x.Name,
                             Price = x.Price
                         })
                          .ToArray()
                     }

                 })
                 .ToArray()
            };


            var sb = new StringBuilder();
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var serializer = new XmlSerializer(typeof(UsersOutDto), new XmlRootAttribute("users"));
            serializer.Serialize(new StringWriter(sb), users, xmlNamespaces);

            File.WriteAllText("../../../Xml/Output/users-and-products.xml", sb.ToString());
        }

        private static void GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                                    .OrderByDescending(c => c.CategoryProducts.Count)
                                    .Select(c => new CategoryOutDto
                                    {
                                        Name = c.Name,
                                        Count = c.CategoryProducts.Count,
                                        TotalRevenue = c.CategoryProducts.Sum(x => x.Product.Price),
                                        AveragePrice = c.CategoryProducts.Select(x => x.Product.Price).DefaultIfEmpty(0).Average()
                                    })
                                    .ToArray();


            var sb = new StringBuilder();
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var serializer = new XmlSerializer(typeof(CategoryOutDto[]), new XmlRootAttribute("categories"));
            serializer.Serialize(new StringWriter(sb), categories, xmlNamespaces);

            File.WriteAllText("../../../Xml/Output/categories-by-products.xml", sb.ToString());
        }

        private static void GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                               .Where(x => x.ProdcutsSold.Count >= 1)
                               .Select(x => new UserOutDto
                               {
                                   FirstName = x.FirstName,
                                   LastName = x.LastName,
                                   SoldProducts = x.ProdcutsSold.Select(p => new SoldProductsOutDto
                                   {
                                       Name = p.Name,
                                       Price = p.Price
                                   })
                                   .ToArray()
                               })
                               .OrderBy(x => x.LastName)
                               .ThenBy(x => x.FirstName)
                               .ToArray();

            var sb = new StringBuilder();
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var serializer = new XmlSerializer(typeof(UserOutDto[]), new XmlRootAttribute("users"));
            serializer.Serialize(new StringWriter(sb), users, xmlNamespaces);

            File.WriteAllText("../../../Xml/Output/users-sold-products.xml", sb.ToString());
        }

        private static void GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                                  .Where(x => x.Price >= 1000 && x.Price <= 2000 && x.Buyer != null)
                                  .OrderByDescending(x => x.Price)
                                  .Select(x => new ProductOutDto
                                  {
                                      Name = x.Name,
                                      Price = x.Price,
                                      Buyer = x.Buyer.FirstName + " " + x.Buyer.LastName ?? x.Buyer.LastName
                                  })
                                  .ToArray();

            var sb = new StringBuilder();
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var serializer = new XmlSerializer(typeof(ProductOutDto[]), new XmlRootAttribute("products"));
            serializer.Serialize(new StringWriter(sb), products, xmlNamespaces);

            File.WriteAllText("../../../Xml/Output/products-in-range.xml", sb.ToString());



        }


        //XML Inserts
        private static void InsertProductCategoriesFromXml(ProductShopContext context, IMapper mapper)
        {

            List<CategoryProduct> categoryProducts = new List<CategoryProduct>();

            for (int productId = 1; productId < 200; productId++)
            {
                var categoryId = new Random().Next(12, 22);


                var categoryProduct = new CategoryProduct
                {
                    CategoryId = categoryId,
                    ProductId = productId
                };

                categoryProducts.Add(categoryProduct);
            }
            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();
        }

        private static void InsertCategoriesFromXml(ProductShopContext context, IMapper mapper)
        {
            var xmlString = File.ReadAllText("../../../Xml/categories.xml");

            var serializer = new XmlSerializer(typeof(CategoryDto[]), new XmlRootAttribute("categories"));
            var deserializedUsers = (CategoryDto[])serializer.Deserialize(new StringReader(xmlString));

            List<Category> categories = new List<Category>();
            foreach (var categoryDto in deserializedUsers)
            {
                if (!IsValid(categoryDto))
                {
                    continue;
                }
                var category = mapper.Map<Category>(categoryDto);
                categories.Add(category);
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();
        }

        private static void InsertProductsFromXml(ProductShopContext context, IMapper mapper)
        {
            var xmlString = File.ReadAllText("../../../Xml/products.xml");

            var serializer = new XmlSerializer(typeof(ProductDto[]), new XmlRootAttribute("products"));
            var deserializedUsers = (ProductDto[])serializer.Deserialize(new StringReader(xmlString));

            List<Product> products = new List<Product>();

            int counter = 4;
            foreach (var productDto in deserializedUsers)
            {
                if (!IsValid(productDto))
                {
                    continue;
                }
                var product = mapper.Map<Product>(productDto);

                var buyerId = new Random().Next(1, 30);
                var sellerId = new Random().Next(31, 56);

                product.BuyerId = buyerId;
                product.SellerId = sellerId;

                if (counter == 4)
                {
                    product.BuyerId = null;
                    counter = 0;
                }

                counter++;

                products.Add(product);
            }

            context.Products.AddRange(products);
            context.SaveChanges();
        }

        private static void InsertUsersFromXml(ProductShopContext context, IMapper mapper)
        {
            var xmlString = File.ReadAllText("../../../Xml/users.xml");

            var serializer = new XmlSerializer(typeof(UserDto[]), new XmlRootAttribute("users"));
            var deserializedUsers = (UserDto[])serializer.Deserialize(new StringReader(xmlString));

            List<User> users = new List<User>();
            foreach (var userDto in deserializedUsers)
            {
                if (!IsValid(userDto))
                {
                    continue;
                }
                var user = mapper.Map<User>(userDto);
                users.Add(user);
            }

            context.Users.AddRange(users);
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