using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _1._4_Winning_Ticket
{
    public class WinningTicket
    {
        public static void Main()
        {
            var tikets = Console.ReadLine().Split(',').Select(x => x.Trim());
            foreach (var ticket in tikets)
            {
                if (ticket.Length == 20)
                {
                    var leftSide = new string(ticket.Take(10).ToArray());
                    var rightSide = new string(ticket.Skip(10).ToArray());
                    var symbols = new string[] { "@", "#", "$", "^" };
                    bool winningTicket = false;

                    foreach (var symbol in symbols)
                    {
                        var regex = new Regex($"\\{symbol}{{6,}}");
                        var leftMatch = regex.Match(leftSide);
                        var rightMatch = regex.Match(rightSide);

                        if (leftMatch.Success && rightMatch.Success)
                        {
                            winningTicket = true;
                            var matchLeftLen = regex.Match(leftSide).Length;
                            var matchRightLen = regex.Match(rightSide).Length;

                            string jackpotMsg = null;
                            if (matchLeftLen == 10 && matchRightLen == 10)
                            {
                                jackpotMsg = "Jackpot!";
                            }

                            Console.WriteLine($"ticket \"{ticket}\" - {Math.Min(matchLeftLen,matchRightLen)}{symbol} {jackpotMsg}");
                            break;
                        }
                    }

                    if (!winningTicket)
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - no match");
                    }
                }
                else
                {
                    Console.WriteLine("invalid ticket");
                }
            }
        }
    }
}
