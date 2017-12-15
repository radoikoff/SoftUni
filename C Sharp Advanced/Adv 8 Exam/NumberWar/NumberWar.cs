using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberWar
{
    class NumberWar
    {
        static void Main()
        {
            var ttt = GetCardPower("345b", 0);

            var firstPlayerCards = Console.ReadLine().Split();
            var secondPlayerCards = Console.ReadLine().Split();

            var firstPlayerDeck = new Queue<string>(firstPlayerCards);
            var secondPlayerDeck = new Queue<string>(secondPlayerCards);
            int turns = -1;
            string result = string.Empty;

            while (true)
            {
                turns++;

                //break rules
                if (turns > 1000000)
                {
                    if (firstPlayerDeck.Count > secondPlayerDeck.Count)
                    {
                        result = "First player wins";
                        break;
                    }
                    else if (firstPlayerDeck.Count < secondPlayerDeck.Count)
                    {
                        result = "Second player wins";
                        break;
                    }
                    else
                    {
                        result = "Draw";
                        break;
                    }
                }


                //start
                string firstCard = "";
                string secondCard = "";

                if (firstPlayerDeck.Count >= 1 && secondPlayerDeck.Count >= 1)
                {
                    firstCard = firstPlayerDeck.Dequeue();
                    secondCard = secondPlayerDeck.Dequeue();
                }
                else
                {
                    if (firstPlayerDeck.Count == secondPlayerDeck.Count)
                    {
                        result = "Draw";
                        break;
                    }
                    if (firstPlayerDeck.Count < 1)
                    {
                        result = "Second player wins";
                        break;
                    }
                    else
                    {
                        result = "First player wins";
                        break;
                    }
                }

                var winHand = new List<string>();
                winHand.Add(firstCard);
                winHand.Add(secondCard);

                if (GetCardPower(firstCard, 0) > GetCardPower(secondCard, 0))
                {
                    foreach (var card in winHand.OrderByDescending(x => x))
                    {
                        firstPlayerDeck.Enqueue(card);
                        continue;
                    }
                }
                else if (GetCardPower(firstCard, 0) < GetCardPower(secondCard, 0))
                {
                    foreach (var card in winHand.OrderByDescending(x => x))
                    {
                        secondPlayerDeck.Enqueue(card);
                        continue;
                    }
                }
                else
                {
                    //war
                    int firstCardPower = 0;
                    int secondCardPower = 0;
                    while (firstCardPower == secondCardPower)
                    {

                        if (firstPlayerDeck.Count >= 3 && secondPlayerDeck.Count >= 3)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                firstCard = firstPlayerDeck.Dequeue();
                                firstCardPower += GetCardPower(firstCard, 1);
                                winHand.Add(firstCard);
                            }

                            for (int i = 0; i < 3; i++)
                            {
                                secondCard = secondPlayerDeck.Dequeue();
                                secondCardPower += GetCardPower(secondCard, 1);
                                winHand.Add(secondCard);
                            }
                        }
                        else
                        {
                            if (firstPlayerDeck.Count == secondPlayerDeck.Count)
                            {
                                result = "Draw";
                                break;
                            }
                            if (firstPlayerDeck.Count < 3)
                            {
                                result = "Second player wins";
                                break;
                            }
                            else
                            {
                                result = "First player wins";
                                break;
                            }
                        }


                        if (firstCardPower > secondCardPower)
                        {
                            foreach (var card in winHand.OrderByDescending(x => x))
                            {
                                firstPlayerDeck.Enqueue(card);
                                continue;
                            }
                        }
                        else if (firstCardPower < secondCardPower)
                        {
                            foreach (var card in winHand.OrderByDescending(x => x))
                            {
                                secondPlayerDeck.Enqueue(card);
                                continue;
                            }
                        }
                    }

                }




            }

            Console.WriteLine($"{result} after {turns} turns");

        }


        public static int GetCardPower(string card, int powerType)
        {
            if (powerType == 0)
            {
                var number = card.Substring(0, card.Length - 1);
                return int.Parse(number);
            }
            else
            {
                var letter = card.Substring(card.Length - 1);
                var result = Convert.ToChar(letter);
                return result;
            }

        }
    }
}
