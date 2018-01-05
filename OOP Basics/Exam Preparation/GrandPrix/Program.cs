using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static void Main()
    {
        var tower = new RaceTower();

        int lapseNumber = int.Parse(Console.ReadLine());
        int trackLength = int.Parse(Console.ReadLine());

        tower.SetTrackInfo(lapseNumber, trackLength);

        while (lapseNumber > 0)
        {
            string[] tokens = Console.ReadLine().Split(' ');
            string command = tokens[0];
            var cmdArgs = tokens.Skip(1).ToList();

            switch (command)
            {
                case "RegisterDriver":
                    tower.RegisterDriver(cmdArgs);
                    break;
                case "Leaderboard":
                    tower.GetLeaderboard();
                    break;
                case "CompleteLaps":
                    Console.WriteLine(tower.CompleteLaps(cmdArgs));
                    break;
                case "Box":
                    break;
                case "ChangeWeather":
                    break;

            }
        }

    }
}
