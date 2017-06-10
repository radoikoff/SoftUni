using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Sequence_with_Queue
{
    public class SequenceWithQueue
    {
        public static void Main()
        {
            double input = double.Parse(Console.ReadLine());
            var data = new Queue<double>();

            data.Enqueue(input);
            for (int i = 0; i < 50; i++)
            {
                double firstValue = data.Peek();
                data.Enqueue(firstValue + 1);
                data.Enqueue(2 * firstValue + 1);
                data.Enqueue(firstValue + 2);
                Console.Write(data.Dequeue() + " ");
            }

        }
    }
}
