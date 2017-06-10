using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Basic_Queue_Operations
{
    public class BasicQueueOps
    {
        public static void Main()
        {
            var command = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var data = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var queue = new Queue<int>();

            for (int i = 0; i < command[0]; i++)
            {
                queue.Enqueue(data[i]);
            }

            for (int i = 0; i < command[1]; i++)
            {
                if (queue.Count == 0)
                {
                    break;
                }
                queue.Dequeue();
            }

            if (queue.Contains(command[2]))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Count != 0 ? queue.Min() : 0);
            }
        }
    }
}
