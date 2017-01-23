using System;

namespace _19.Thea_the_Photographer
{
    class Program
    {
        static void Main()
        {
            long picsTaken = int.Parse(Console.ReadLine());
            int filterTimePerPic = int.Parse(Console.ReadLine());
            int percentGoodPics = int.Parse(Console.ReadLine());
            int uploadTimePerPic = int.Parse(Console.ReadLine());

            long filterTime = picsTaken * filterTimePerPic;
            long numberGoodPics = (long)Math.Ceiling(picsTaken * percentGoodPics / 100.0);
            long uploadTime = numberGoodPics * uploadTimePerPic;
            long totalTime = filterTime + uploadTime;

            long days = totalTime / (3600 * 24);
            long hours = (totalTime % (3600 * 24)) / 3600;
            long min = ((totalTime % (3600 * 24)) % 3600) / 60;
            long sec = ((totalTime % (3600 * 24)) % 3600) % 60;
            Console.WriteLine($"{days:0}:{hours:00}:{min:00}:{sec:00}");

            //TimeSpan result = new TimeSpan(0, 0, totalTime);
            //Console.WriteLine(result.ToString(@"d\:hh\:mm\:ss"));

        }
    }
}
