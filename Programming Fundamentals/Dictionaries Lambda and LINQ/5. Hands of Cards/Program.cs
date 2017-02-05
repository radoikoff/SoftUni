using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.Hands_of_Cards
{
    class Program
    {
        public static void Main()
        {
            var cardsInfo = new Dictionary<string, List<string>>();
            var cardPowers = GetCardPowers();
            var cardTypes = GetCardTypes();
            string input = Console.ReadLine();
            while (input != "JOKER")
            {

                var item = input.Split(':');
                var playerName = item[0];
                var playerCards = item[1].Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries); //.Distinct();

                foreach (var card in playerCards)
                {
                    if (!cardsInfo.ContainsKey(playerName))
                    {
                        cardsInfo.Add(playerName, new List<string>());
                    }

                    cardsInfo[playerName].AddRange(playerCards);
                }

                input = Console.ReadLine();
            }

            foreach (var player in cardsInfo)
            {
                var cards = player.Value.Distinct();
                int points = 0;
                foreach (var card in cards)
                {
                    var cardPower = card.Substring(0, card.Length - 1);
                    var cardType = card.Substring(card.Length - 1);
                    points += cardPowers[cardPower] * cardTypes[cardType];
                }

                Console.WriteLine($"{player.Key}: {points}");
            }
        }

        public static Dictionary<string, int> GetCardPowers()
        {
            var power = new Dictionary<string, int>();
            for (int i = 2; i <=10; i++)
            {
                power[i.ToString()] = i;
            }
            power["J"] = 11;
            power["Q"] = 12;
            power["K"] = 13;
            power["A"] = 14;

            return power;
        }

        public static Dictionary<string, int> GetCardTypes()
        {
            var type = new Dictionary<string, int>();
            
            type["S"] = 4;
            type["H"] = 3;
            type["D"] = 2;
            type["C"] = 1;

            return type;
        }
    }

}


