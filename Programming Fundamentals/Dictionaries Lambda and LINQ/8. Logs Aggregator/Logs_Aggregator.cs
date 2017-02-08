using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.Logs_Aggregator
{
    public class Logs_Aggregator
    {
        static void Main()
        {
            var userIpAddresses = new SortedDictionary<string, List<string>>();
            var userSessionDurations = new Dictionary<string, int>();
                int numberOfLogs = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfLogs; i++)
            {
                var tokens = Console.ReadLine().Split(' ');
                string ip = tokens[0];
                string userName = tokens[1];
                int sessionDuration = int.Parse(tokens[2]);

                if (!userIpAddresses.ContainsKey(userName))
                {
                    userIpAddresses[userName] = new List<string>();
                }
                userIpAddresses[userName].Add(ip);

                if (!userSessionDurations.ContainsKey(userName))
                {
                    userSessionDurations[userName] = 0; 
                }
                userSessionDurations[userName] += sessionDuration;

                
            }

            foreach (var user in userIpAddresses)
            {
                var ipList = user.Value;
                var sortedIpList = ipList.OrderBy(a => a).Distinct();
                int totalDuration = userSessionDurations[user.Key];
                Console.WriteLine($"{user.Key}: {totalDuration} [{string.Join(", ",sortedIpList)}]");
            }
        }
    }
}
