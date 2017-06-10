using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Poisonous_Plants
{
    public class PoisonousPlants
    {
        public static void Main()
        {
            int plantsNumber = int.Parse(Console.ReadLine());
            var pesticideData = Console.ReadLine().Split().Select(double.Parse).Reverse();
            var data = new Queue<double>(pesticideData);
            int count = 0;

            while (true)
            {
                for (int i = 1; i <= plantsNumber; i++)
                {
                    var lastPlant = data.Dequeue();
                    if (data.Count != 0)
                    {
                        if (lastPlant <= data.Peek() || i == plantsNumber)
                        {
                            data.Enqueue(lastPlant);
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                //Console.WriteLine(string.Join(" ",data));
                if (plantsNumber != data.Count())
                {
                    plantsNumber = data.Count();
                    count++;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(count);
        }
    }
}
