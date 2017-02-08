using System;
using System.Collections.Generic;
using System.Linq;

namespace _9.Legendary_Farming
{
    class Legendary_Farming
    {
        public static void Main()
        {
            var keyMaterials = new Dictionary<string, int>();
            var junkMaterials = new Dictionary<string, int>();
            string keyMaterialWin = string.Empty;
            bool readInput = true;

            keyMaterials.Add("shards", 0);
            keyMaterials.Add("fragments", 0);
            keyMaterials.Add("motes", 0);

            for (int j = 0; j < 10; j++)
            {
                var input = Console.ReadLine().Split();
                for (int i = 0; i < input.Length; i += 2)
                {
                    var materialName = input[i + 1].ToLower();
                    var materialQuantity = int.Parse(input[i]);

                    if (materialName == "shards" || materialName == "fragments" || materialName == "motes")
                    {
                        keyMaterials[materialName] += materialQuantity;
                        if (keyMaterials[materialName] >= 250)
                        {
                            keyMaterialWin = materialName;
                            readInput = false;
                            break;
                        }
                    }
                    else
                    {
                        if (!junkMaterials.ContainsKey(materialName))
                        {
                            junkMaterials[materialName] = 0;
                        }
                        junkMaterials[materialName] += materialQuantity;
                    }
                }
                if (!readInput)
                {
                    break;
                }
            }

            switch (keyMaterialWin)
            {
                case "shards":
                    Console.WriteLine("Shadowmourne obtained!");
                    break;
                case "fragments":
                    Console.WriteLine("Valanyr obtained!");
                    break;
                case "motes":
                    Console.WriteLine("Dragonwrath obtained!");
                    break;
            }

            keyMaterials[keyMaterialWin] -= 250;
            var sortedKeyMaterials = keyMaterials.OrderByDescending(z => z.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var material in sortedKeyMaterials)
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }

            var sortedJunkMaterials = junkMaterials.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var material in sortedJunkMaterials)
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }
        }
    }
}
