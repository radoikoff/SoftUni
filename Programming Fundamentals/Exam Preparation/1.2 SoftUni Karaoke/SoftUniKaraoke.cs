using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._2_SoftUni_Karaoke
{
    public class SoftUniKaraoke
    {
        public static void Main()
        {
            var participants = Console.ReadLine().Split(',').Select(p => p.Trim()).ToList();
            var songs = Console.ReadLine().Split(',').Select(s => s.Trim()).ToList();
            var awards = new Dictionary<string, List<string>>();

            string performance = Console.ReadLine();
            while (performance != "dawn")
            {
                var tokens = performance.Split(',').Select(p => p.Trim()).ToArray();
                string participant = tokens[0];
                string song = tokens[1];
                string award = tokens[2];

                if (participants.Contains(participant) && songs.Contains(song))
                {
                    if (!awards.ContainsKey(participant))
                    {
                        awards[participant] = new List<string>();
                    }

                    if (!awards[participant].Contains(award))
                    {
                        awards[participant].Add(award);
                    }
                }
                performance = Console.ReadLine();
            }
            if (awards.Keys.Any())
            {
                foreach (var participant in awards.OrderByDescending(p => p.Value.Count()).ThenBy(p => p.Key))
                {
                    var awardCount = participant.Value.Count();
                    Console.WriteLine($"{participant.Key}: {awardCount} awards");
                    foreach (var award in participant.Value.OrderBy(x => x))
                    {
                        Console.WriteLine($"--{award}");
                    }
                }
            }
            else
            {
                Console.WriteLine("No awards");
            }
            
        }
    }
}
