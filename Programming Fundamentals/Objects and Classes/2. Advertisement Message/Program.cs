using System;

namespace _2.Advertisement_Message
{
    class Program
    {
        public static void Main()
        {
            int requiredLines = int.Parse(Console.ReadLine());

            var phrases = new string[]
            {
              "Excellent product.",
              "Such a great product.",
              "I always use that product.",
              "Best product of its category.",
              "Exceptional product.",
              "I can’t live without this product."
            };

            var events = new string[]
            {
                "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"
            };

            var authors = new string[] {"Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"};
            var cities = new string[] {"Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"};

            Random random = new Random();
            for (int i = 0; i < requiredLines; i++)
            {
                int phraseIndex = random.Next(0, phrases.Length);
                int eventIndex = random.Next(0, events.Length);
                int authorIndex = random.Next(0, authors.Length);
                int citiesIndex = random.Next(0, cities.Length);
                Console.WriteLine($"{phrases[phraseIndex]} {events[eventIndex]} {authors[authorIndex]} – {cities[citiesIndex]}");
            }
          
        }
    }
}
