using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.User_Logs
{
    class User_Logs
    {
        public static void Main()
        {
            var usersIpAdresses = new SortedDictionary<string, List<string>>();
            var line = Console.ReadLine();

            while (line != "end")
            {
                var tokens = line.Split(' ');
                string Ip = tokens[0].Substring(3);
                string user = tokens[2].Substring(5);

                if (!usersIpAdresses.ContainsKey(user))
                {
                    usersIpAdresses[user] = new List<string>();
                }
                usersIpAdresses[user].Add(Ip);
                line = Console.ReadLine();
            }

            foreach (var user in usersIpAdresses)
            {
                var userIpCount = new Dictionary<string, int>();
                var ipList = user.Value;
                foreach (var ip in ipList)
                {
                    if (!userIpCount.ContainsKey(ip))
                    {
                        userIpCount[ip] = 0;
                    }
                    userIpCount[ip] += 1;
                }

                Console.WriteLine($"{user.Key}:");
                var result = new List<string>();
                foreach (var ip in userIpCount)
                {
                    result.Add($"{ip.Key} => {ip.Value}");
                }
                Console.WriteLine($"{string.Join(", ", result)}.");
            }
        }
    }
}
