using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Hornet_Armanda
{
    public class HornetArmanda
    {
        public static void Main()
        {

            var legions = new Dictionary<string, Dictionary<string, long>>();
            var activities = new Dictionary<string, long>();


            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(new char[] { '=', '-', '>', ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                long lastActivity = long.Parse(tokens[0]);
                string legionName = tokens[1];
                string soldierType = tokens[2];
                long soldierCount = long.Parse(tokens[3]);

                if (!legions.ContainsKey(legionName))
                {
                    legions[legionName] = new Dictionary<string, long>();
                    activities[legionName] = 0;
                }

                if (!legions[legionName].ContainsKey(soldierType))
                {
                    legions[legionName][soldierType] = 0;
                }

                legions[legionName][soldierType] += soldierCount;
                if (lastActivity > activities[legionName])
                {
                    activities[legionName] = lastActivity;
                }
            }

            var input = Console.ReadLine();
            int activity = 0;
            string soldierType2 = null;
            bool scenario = true;
            if (input.Contains('\\'))
            {
                var tokens = input.Split('\\');
                activity = int.Parse(tokens[0]);
                soldierType2 = tokens[1];
                scenario = true;
            }
            else
            {
                soldierType2 = input;
                scenario = false;
            }

            if (scenario)
            {
                var tempList = new Dictionary<string, long>();

                var ttt = activities.Where(x => x.Value > activity);
                foreach (var item in activities.Where(x => x.Value < activity))
                {
                    long soldersCount = 0;
                    foreach (var aa in legions[item.Key])
                    {
                        if (aa.Key == soldierType2)
                        {
                            soldersCount += aa.Value;
                        }
                    }
                    tempList.Add(item.Key, soldersCount);
                    //Console.WriteLine($"{item.Key} -> {soldersCount}");
                }
                tempList.OrderBy(x => x.Value);
                foreach (var item in tempList)
                {
                    Console.WriteLine($"{item.Key} -> {item.Value}");
                }
            }
            else
            {
                foreach (var item in activities.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"{item.Value} : {item.Key}");
                }
            }

        }
    }
}
