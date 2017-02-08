using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.Fix_Emails
{
    class Fix_Emails
    {
        private static IEnumerable<object> fixedMailAddr;

        public static void Main()
        {
            var mailAddr = new Dictionary<string, string>();
            string input = Console.ReadLine();
            while (input != "stop")
            {
                string name = input;
                string email = Console.ReadLine();

                mailAddr[name] = email;
        
                input = Console.ReadLine();
            }
            var fixedMailAddr = mailAddr.Where(a => a.Value.ToLower().Substring(a.Value.Length - 2, 2) != "us" && 
                                                       a.Value.ToLower().Substring(a.Value.Length - 2, 2) != "uk");
            foreach (var pair in fixedMailAddr)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}
