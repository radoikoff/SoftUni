using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyRevolver
{
    class KeyRevolver
    {
        static void Main(string[] args)
        {
            var bulletPrice = int.Parse(Console.ReadLine());
            var gunBarrelSize = int.Parse(Console.ReadLine());
            var bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            var locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            var intelValue = int.Parse(Console.ReadLine());

            int moneyEarned = intelValue;
            int shootsCount = 0;

            while (bullets.Count != 0 && locks.Count != 0)
            {


                var currentBullet = bullets.Pop();
                moneyEarned -= bulletPrice;
                shootsCount++;
                var currentLock = locks.Peek();

                if (currentBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (shootsCount >= gunBarrelSize && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    shootsCount = 0;
                }

            }

            if (locks.Count == 0)
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}
