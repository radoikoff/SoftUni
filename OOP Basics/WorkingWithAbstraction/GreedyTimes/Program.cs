using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyTimes
{
    class Program
    {
        static void Main(string[] args)
        {

            long bagMaxCapacity = long.Parse(Console.ReadLine());
            string[] vault = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bag = new Bag();

            for (int i = 0; i < vault.Length; i += 2)
            {
                string itemName = vault[i];
                long currentItemAmount = long.Parse(vault[i + 1]);


                if (bagMaxCapacity >= bag.BagCurrentAmount + currentItemAmount)
                {
                    if (itemName.Length == 3) //cash
                    {
                        bag.AddCash(itemName, currentItemAmount);
                    }
                    else if (itemName.ToLower().EndsWith("gem")) //gem
                    {
                        bag.AddGem(itemName, currentItemAmount);
                    }
                    else if (itemName.ToLower() == "gold") // gold
                    {
                        bag.AddGold(currentItemAmount);
                    }
                }

            }
            Console.WriteLine(bag.ToString());

        }
    }
}
