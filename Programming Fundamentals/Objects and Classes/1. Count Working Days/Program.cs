using System;
using System.Collections.Generic;
using System.Globalization;

namespace _1.Count_Working_Days
{
    class Program
    {
        public static void Main()
        {
            var str = Console.ReadLine();
            DateTime startDate = DateTime.ParseExact(str, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var holidays = new List<DateTime>();
            double workingDaysCounter = 0;

            holidays.Add(new DateTime(1900, 1, 1));
            holidays.Add(new DateTime(1900, 3, 3));
            holidays.Add(new DateTime(1900, 5, 1));
            holidays.Add(new DateTime(1900, 5, 6));
            holidays.Add(new DateTime(1900, 5, 24));
            holidays.Add(new DateTime(1900, 9, 6));
            holidays.Add(new DateTime(1900, 9, 22));
            holidays.Add(new DateTime(1900, 11, 1));
            holidays.Add(new DateTime(1900, 12, 24));
            holidays.Add(new DateTime(1900, 12, 25));
            holidays.Add(new DateTime(1900, 12, 26));

            double totalDays = endDate.Subtract(startDate).Days + 1;
            DateTime currentDay = startDate;

            for (double i = 1; i <= totalDays; i++)
            {
                bool isSaturday = currentDay.DayOfWeek.ToString() == "Saturday";
                bool isSunday = currentDay.DayOfWeek.ToString() == "Sunday";
                bool isHoliday = false;

                foreach (var holiday in holidays)
                {
                    if (holiday.Day == currentDay.Day && holiday.Month == currentDay.Month)
                    {
                        isHoliday = true;
                        break;
                    }
                }
                if (!isSaturday && !isSunday && !isHoliday)
                {
                    workingDaysCounter++;
                }
                currentDay = currentDay.AddDays(1);
            }
            Console.WriteLine(workingDaysCounter);
        }
    }
}
