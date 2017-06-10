using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Unique_Usernames
{
    public class UniqueUsernames
    {
        public static void Main()
        {
            var input = int.Parse(Console.ReadLine());
            var users = new HashSet<string>();

            for (int i = 0; i < input; i++)
            {
                users.Add(Console.ReadLine());
            }

            foreach (var user in users)
            {
                Console.WriteLine(user);
            }
        }
    }
}
