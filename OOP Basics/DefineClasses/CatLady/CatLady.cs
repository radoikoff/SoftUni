using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatLady
{
    public class CatLady
    {
        public static void Main()
        {
            var cats = new List<Cat>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var name = tokens[1];
                switch (tokens[0])
                {
                    case "Siamese":
                        cats.Add(new SiameseCat(name, int.Parse(tokens[2])));
                        break;
                    case "Cymric":
                        cats.Add(new CymricCat(name, double.Parse(tokens[2])));
                        break;
                    case "StreetExtraordinaire":
                        cats.Add(new StreetExtraordinaireCat(name, int.Parse(tokens[2])));
                        break;
                }
            }

            var catNameToReport = Console.ReadLine().Trim();
            Console.WriteLine(cats.FirstOrDefault(c => c.Name == catNameToReport).ToString());

        }
    }
}
