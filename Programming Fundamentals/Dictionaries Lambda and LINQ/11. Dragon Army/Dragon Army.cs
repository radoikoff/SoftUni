using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.Dragon_Army
{
    public class Dragon_Army
    {
        static void Main()
        {
            var dragons = new Dictionary<string, SortedDictionary<string, int[]>>();
            int input = int.Parse(Console.ReadLine());
            for (int i = 0; i < input; i++)
            {
                var tokens = Console.ReadLine().Split();  //{type} {name} {damage} {health} {armor}
                string type = tokens[0];
                string name = tokens[1];

                int damage, health, armor;
                if (tokens[2] != "null")
                {
                    damage = int.Parse(tokens[2]);
                }
                else
                {
                    damage = 45;
                }

                if (tokens[3] != "null")
                {
                    health = int.Parse(tokens[3]);
                }
                else
                {
                    health = 250;
                }

                if (tokens[4] != "null")
                {
                    armor = int.Parse(tokens[4]);
                }
                else
                {
                    armor = 10;
                }

                //fill the data in
                if (!dragons.ContainsKey(type))
                {
                    dragons.Add(type, new SortedDictionary<string, int[]>());
                }
                if (!dragons[type].ContainsKey(name))
                {
                    dragons[type].Add(name, new int[3]);
                }
                dragons[type][name][0] = damage;
                dragons[type][name][1] = health;
                dragons[type][name][2] = armor;
            }
            //report data
            foreach (var dragonType in dragons)
            {
                var type = dragonType.Key;
                var averageDamage = dragonType.Value.Average(x => x.Value[0]);
                var averageHealth = dragonType.Value.Average(x => x.Value[1]);
                var averageArmor = dragonType.Value.Average(x => x.Value[2]);
                Console.WriteLine($"{type}::({averageDamage:F2}/{averageHealth:F2}/{averageArmor:F2})");

                foreach (var dragonNameStats in dragonType.Value)
                {
                    var name = dragonNameStats.Key;
                    var stats = dragonNameStats.Value;
                    int damage = stats[0];
                    int health = stats[1];
                    int armor = stats[2];
                    Console.WriteLine($"-{name} -> damage: {damage}, health: {health}, armor: {armor}");
                }
            }
        }
    }
}
