﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _5.Book_Library
{
    class Book_Library
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

            var authors = myLibrary.Books.OrderByDescending(x => x.Price).ThenBy(x => x.Author).Select(x => x.Author).Distinct().ToList();
            foreach (var author in authors)
            {
                var sum = myLibrary.Books.Where(x => x.Author == author).Sum(x => x.Price);
                Console.WriteLine($"{author} -> {sum:F2}");
            }

        }
    }
}
