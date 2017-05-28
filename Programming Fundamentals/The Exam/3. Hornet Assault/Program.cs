using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.Hornet_Assault
{
    public class Program
    {
        public static void Main()
        {
            var input1 = Console.ReadLine();
            var input2 = Console.ReadLine();
            if (input1.Any() && input2.Any())
            {

                var hives = input1.Split(' ').Select(long.Parse).ToArray();
                var hornets = input2.Split(' ').Select(long.Parse).ToArray();

                var newHives = new List<long>();
                List<long> newHornets = hornets.ToList();


                long hornetsPower = hornets.Sum();

                for (int i = 0; i < hives.Length; i++)
                {
                    if (hornetsPower <= hives[i])
                    {

                        if (hives[i] - hornetsPower != 0)
                        {
                            newHives.Add(hives[i] - hornetsPower); //alive bees
                        }
                        if (newHornets.Any())
                        {
                            newHornets.RemoveAt(0);
                        }
                        hornetsPower = newHornets.Sum();
                    }
                }


                if (newHives.Any())
                {
                    Console.WriteLine(string.Join(" ", newHives));
                }
                else
                {
                    Console.WriteLine(string.Join(" ", newHornets));
                }
            }
        }
    }
}



