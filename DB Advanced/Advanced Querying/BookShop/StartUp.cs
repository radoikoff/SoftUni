namespace BookShop
{
    using BookShop.Data;
    using BookShop.Initializer;
    using BookShop.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(db);
                //string command = Console.ReadLine();
                //string result = GetBooksByAgeRestriction(db, command);

                //int lenght = int.Parse(Console.ReadLine());
                var result = GetTotalProfitByCategory(db);

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

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime inputDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                               .Where(b => b.ReleaseDate.Value < inputDate)
                               .OrderByDescending(b => b.ReleaseDate)
                               .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:F2}")
                               .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                                 .Where(a => a.FirstName.EndsWith(input, StringComparison.InvariantCultureIgnoreCase))
                                 .Select(a => new
                                 {
                                     a.FirstName,
                                     a.LastName
                                 })
                                 .OrderBy(a => a.FirstName)
                                 .ThenBy(a => a.LastName)
                                 .Select(a => $"{a.FirstName} {a.LastName}")
                                 .ToArray();

            return string.Join(Environment.NewLine, authors);
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                               .Where(b => EF.Functions.Like(b.Title, $"%{input}%"))
                               .Select(b => b.Title)
                               .OrderBy(b => b)
                               .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                               .Include(x => x.Author)
                               .Where(b => EF.Functions.Like(b.Author.LastName, $"{input}%"))
                               .Select(x => $"{x.Title} ({x.Author.FirstName} {x.Author.LastName})")
                               .ToArray();

            return string.Join(Environment.NewLine, books);

        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var booksCount = context.Books
                                    .Where(b => b.Title.Length > lengthCheck)
                                    .Count();

            return booksCount;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context.Authors
                                 .Select(a => new
                                 {
                                     FullName = a.FirstName + " " + a.LastName,
                                     TotalCopies = a.Books.Sum(b => b.Copies)
                                 })
                                 .OrderByDescending(x => x.TotalCopies)
                                 .ToArray();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FullName} - {author.TotalCopies}");
            }

            return sb.ToString().TrimEnd();

        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categories = context.Categories
                                 .Select(c => new
                                 {
                                     c.Name,
                                     TotalProfit = c.CategoryBooks.Sum(b => b.Book.Price * b.Book.Copies)
                                 })
                                 .OrderByDescending(x => x.TotalProfit)
                                 .ThenBy(x => x.Name)
                                 .ToArray();

            foreach (var category in categories)
            {
                sb.AppendLine($"{category.Name} ${category.TotalProfit:F2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
