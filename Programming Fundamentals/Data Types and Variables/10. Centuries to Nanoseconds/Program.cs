using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Centuries_to_Nanoseconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int centuries = int.Parse(Console.ReadLine());
            int years = centuries * 100;
            int days = (int)(years * 365.2422);
            long hours = 24 * days;
            long minutes = 60 * hours;
            long sec = minutes * 60;
            ulong ms = (ulong)(sec * 1000);
            BigInteger microsecond = ms * 1000;
            BigInteger ns = microsecond * 1000;
            Console.WriteLine("{0} centuries = {1} years = {2} days = {3} hours = {4} minutes = {5} seconds = {6} milliseconds = {7} microseconds = {8} nanoseconds", centuries, years, days, hours, minutes, sec, ms, microsecond, ns);

        }
    }
}
