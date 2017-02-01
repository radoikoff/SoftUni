using System;

namespace _4.Sieve_of_Eratosthenes
{
    class Program
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            var primes = new bool[number+1];

            if (number >= 2)
            {
                for (int i = 0; i < primes.Length; i++)
                {
                    primes[i] = true;
                }

                primes[0] = primes[1] = false;

                for (long p = 2; p <= number; p++)
                {
                    if (primes[p] == true)
                    {
                        Console.Write("{0} ", p);
                        for (long j = 2; j * p < primes.Length; j++)
                        {
                            primes[j * p] = false;
                        }
                    }
                }
            }
        }
    }
}
