using System;

namespace ProblemOne
{
    public class HornetWings
    {
        public static void Main()
        {
            int contestFlaps = int.Parse(Console.ReadLine());
            double distancePer1kFlaps = double.Parse(Console.ReadLine());
            int enduranceFlaps = int.Parse(Console.ReadLine());

            double distanceTraveled = contestFlaps / 1000 * distancePer1kFlaps;

            int flightTime = contestFlaps / 100;
            int restTime = 0;
            int timePassed = 0;

            if (contestFlaps != enduranceFlaps)
            {
                restTime = contestFlaps / enduranceFlaps * 5;
            }
            if (distancePer1kFlaps != 0)
            {
                timePassed = flightTime + restTime;
            }

            Console.WriteLine($"{distanceTraveled:F2} m.");
            Console.WriteLine($"{timePassed} s.");
        }
    }
}
