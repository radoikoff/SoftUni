﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _3.Valid_Usernames
{
    public class ValidUsernames
    {
        public static void Main()
        {
            var users = new List<string>();
            string[] input = Console.ReadLine().Split(new char[] { ' ', '/', '\\', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);

            string pattern = @"^[A-Za-z]\w{2,24}$";
            Regex regex = new Regex(pattern);

            foreach (var user in input)
            {
                if (regex.IsMatch(user))
                {
                    users.Add(user);
                }
            }

            int sumlength = 0;
            int maxSumLength = 0;
            int firstUserIndex = 0;

            for (int i = 0; i < users.Count - 1; i++)
            {
                sumlength = users[i].Length + users[i + 1].Length;
                if (sumlength > maxSumLength)
                {
                    maxSumLength = sumlength;
                    firstUserIndex = i;
                }
            }

            Console.WriteLine(users[firstUserIndex]);
            Console.WriteLine(users[firstUserIndex+1]);
        }
    }
}
