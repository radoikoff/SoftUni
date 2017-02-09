using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _6.Book_Library_Modification
{
    public class Book_Library_Modification
    {
        public static void Main()
        {
            var myLibrary = new Library();
            myLibrary.Books = new List<Book>();
            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                var tokens = Console.ReadLine().Split();  //title, author, publisher, release date, ISBN, price. 
                Book currentBook = new Book
                {
                    Title = tokens[0],
                    Author = tokens[1],
                    Publisher = tokens[2],
                    ReleaseDate = DateTime.ParseExact(tokens[3], "dd.MM.yyyy", CultureInfo.InvariantCulture),
                    ISBN = long.Parse(tokens[4]),
                    Price = decimal.Parse(tokens[5])
                };
                myLibrary.Books.Add(currentBook);
            }
            var triggerDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

            foreach (var book in myLibrary.Books.Where(x => x.ReleaseDate > triggerDate).OrderBy(x => x.ReleaseDate).ThenBy(x => x.Title))
            {
                Console.WriteLine($"{book.Title} -> {book.ReleaseDate:dd.MM.yyyy}");
            }
        }
    }
}
