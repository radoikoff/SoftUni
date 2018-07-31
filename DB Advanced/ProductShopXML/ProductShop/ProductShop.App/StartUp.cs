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

    public class StartUp
    {
        public static void Main()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<ProductShopProfile>());
            var mapper = config.CreateMapper();

            var context = new ProductShopContext();

            //InsertUsersFromXml(context, mapper);
            //InsertProductsFromXml(context, mapper);
            //InsertCategoriesFromXml(context, mapper);
            //InsertProductCategoriesFromXml(context, mapper);

        }

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