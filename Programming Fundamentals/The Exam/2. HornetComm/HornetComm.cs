using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _2.HornetComm
{
    public class HornetComm
    {
        public static void Main()
        {
            var privateMsgs = new Dictionary<string, List<string>>();
            var broadcastMsgs = new Dictionary<string, string>();

            string input = Console.ReadLine();
            int i = 0;
            while (input != "Hornet is Green")
            {
                i++;
                if (i > 200)
                {
                    break;
                }

                var regex = new Regex(@"(^\d+)( <-> )([A-Za-z0-9]+$)");

                if (regex.IsMatch(input))
                {
                    var match = regex.Match(input);
                    string recipientCode = new string(match.Groups[1].Value.Reverse().ToArray());
                    string message = match.Groups[3].Value;

                    if (!privateMsgs.ContainsKey(recipientCode))
                    {
                        privateMsgs[recipientCode] = new List<string>();
                    }
                    privateMsgs[recipientCode].Add(message);
                }



                regex = new Regex(@"(^[^0-9]+)( <-> )([A-Za-z0-9]+$)");

                if (regex.IsMatch(input))
                {
                    var match = regex.Match(input);
                    string message = match.Groups[1].Value;
                    var frequency = match.Groups[3].Value;
                    frequency = ReverseLetterCases(frequency);

                    if (!broadcastMsgs.ContainsKey(frequency))
                    {
                        broadcastMsgs[frequency] = null;
                    }
                    broadcastMsgs[frequency] = message;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Broadcasts:");
            if (broadcastMsgs.Count != 0)
            {
                foreach (var msg in broadcastMsgs)
                {
                    Console.WriteLine($"{msg.Key} -> {msg.Value}");
                }
            }
            else
            {
                Console.WriteLine("None");
            }

            Console.WriteLine("Messages:");
            if (privateMsgs.Count != 0)
            {
                foreach (var kvp in privateMsgs)
                {
                    foreach (var msg in kvp.Value)
                    {
                        Console.WriteLine($"{kvp.Key} -> {msg}");
                    }

                }
            }
            else
            {
                Console.WriteLine("None");
            }

        }



        public static string ReverseLetterCases(string frequency)
        {
            var lettersList = new List<char>();
            foreach (char letter in frequency)
            {
                if (letter >= 'a' && letter <= 'z')
                {
                    char newLetter = (char)(letter - 32);
                    lettersList.Add(newLetter);
                }
                else if (letter >= 'A' && letter <= 'Z')
                {
                    char newLetter = (char)(letter + 32);
                    lettersList.Add(newLetter);
                }
                else
                {
                    lettersList.Add(letter);
                }
            }
            return new string(lettersList.ToArray());
            //return frequency;
        }
    }
}
