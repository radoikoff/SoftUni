using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitList
{
    class HitList
    {
        static void Main()
        {
            var data = new Dictionary<string, Dictionary<string, string>>();

            var targetInfoIndex = int.Parse(Console.ReadLine());
            string input = String.Empty;
            while ((input = Console.ReadLine()) != "end transmissions")
            {
                var tokens = input.Split('=');
                string name = tokens[0];
                if (!data.ContainsKey(name))
                {
                    data.Add(name, new Dictionary<string, string>());
                }

                string[] personInfos = tokens[1].Split(';');
                foreach (var info in personInfos)
                {
                    string[] kvp = info.Split(':');
                    var key = kvp[0];
                    var value = kvp[1];
                    if (!data[name].ContainsKey(key))
                    {
                        data[name].Add(key, value);
                    }
                    data[name][key] = value;
                }
            }
            var killName = Console.ReadLine().Split().Skip(1).First();


            //output
            Console.WriteLine($"Info on {killName}:");
            foreach (var personInfo in data[killName].OrderBy(i => i.Key))
            {
                Console.WriteLine($"---{personInfo.Key}: {personInfo.Value}");
            }
            var infoIndex = data[killName].Sum(i => i.Key.Length) + data[killName].Sum(i => i.Value.Length);
            Console.WriteLine($"Info index: {infoIndex}");

            if (infoIndex >= targetInfoIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {targetInfoIndex - infoIndex} more info.");
            }
        }
    }
}
