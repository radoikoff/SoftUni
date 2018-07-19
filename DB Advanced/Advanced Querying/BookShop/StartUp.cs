﻿namespace BookShop
{
    using BookShop.Data;
    using BookShop.Initializer;
    using BookShop.Models;
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(db);
                string command = Console.ReadLine();
                //string result = GetBooksByAgeRestriction(db, command);

                //int year = int.Parse(Console.ReadLine());
                string result = GetBooksByCategory(db, command);

                Console.WriteLine(result);

            }



        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var ageRestriction = (AgeRestriction)Enum.Parse(typeof(AgeRestriction), command, true);

            var books = context.Books
                               .Where(b => b.AgeRestriction == ageRestriction)
                               .OrderBy(b => b.Title)
                               .Select(b => b.Title)
                               .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                   .Where(b => b.Copies < 5000 && b.EditionType == EditionType.Gold)
                   .OrderBy(b => b.BookId)
                   .Select(b => b.Title)
                   .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                               .Where(b => b.Price > 40)
                               .Select(b => new
                               {
                                   b.Title,
                                   b.Price
                               })
                               .OrderByDescending(b => b.Price)
                               .Select(b => $"{b.Title} - ${b.Price:F2}")
                               .ToArray();


            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksNotRealeasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                   .Where(b => b.ReleaseDate.Value.Year != year)
                   .OrderBy(b => b.BookId)
                   .Select(b => b.Title)
                   .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            var books = context.Books
                  .Where(b => b.BookCategories.Any(c => categories.Contains(c.Category.Name.ToLower())))
                  .Select(b => b.Title)
                  .OrderBy(b => b)
                  .ToArray();

            return string.Join(Environment.NewLine, books);
        }
    }
}
