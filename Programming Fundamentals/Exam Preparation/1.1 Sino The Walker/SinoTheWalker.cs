using System;
using System.Linq;

namespace _1._1_Sino_The_Walker
{
    public class SinoTheWalker
    {
        public static void Main()
        {
            var initialTime = Console.ReadLine().Split(':').Select(int.Parse).ToArray();
            int numberOfSteps = int.Parse(Console.ReadLine());
            int secondsPerStep = int.Parse(Console.ReadLine());

            int initialTimeInSeconds = initialTime[0] * 60 * 60 + initialTime[1] * 60 + initialTime[2];
            ulong totalWalkingTime = (ulong)numberOfSteps * (ulong)secondsPerStep;
            totalWalkingTime += (ulong)initialTimeInSeconds;

            ulong seconds = totalWalkingTime % 60;
            ulong minutesConverted = totalWalkingTime / 60;
            ulong minutes = minutesConverted % 60;
            ulong hoursConverted = minutesConverted / 60;
            ulong hours = hoursConverted % 24;

            Console.WriteLine($"Time Arrival: {hours:00}:{minutes:00}:{seconds:00}");
        }
    }
}
