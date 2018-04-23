using DungeonsAndCodeWizards.Core;
using System;
using System.Linq;

namespace DungeonsAndCodeWizards
{
    public class StartUp
    {
        // DO NOT rename this file's namespace or class name.
        // However, you ARE allowed to use your own namespaces (or no namespaces at all if you prefer) in other classes.
        public static void Main(string[] args)
        {

            var master = new DungeonMaster();

            string input = Console.ReadLine();
            bool isInputValid = !string.IsNullOrWhiteSpace(input);
            bool isGameOver = !master.IsGameOver();

            while (isInputValid && isGameOver)
            {
                var tokens = input.Split();
                var command = tokens[0];
                tokens = tokens.Skip(1).ToArray();

                try
                {
                    switch (command.Trim())
                    {
                        case "JoinParty":
                            Console.WriteLine(master.JoinParty(tokens));
                            break;
                        case "AddItemToPool":
                            Console.WriteLine(master.AddItemToPool(tokens));
                            break;
                        case "PickUpItem":
                            Console.WriteLine(master.PickUpItem(tokens));
                            break;
                        case "UseItem":
                            Console.WriteLine(master.UseItem(tokens));
                            break;
                        case "UseItemOn":
                            Console.WriteLine(master.UseItemOn(tokens));
                            break;
                        case "GiveCharacterItem":
                            Console.WriteLine(master.GiveCharacterItem(tokens));
                            break;
                        case "GetStats":
                            Console.WriteLine(master.GetStats());
                            break;
                        case "Attack":
                            Console.WriteLine(master.Attack(tokens));
                            break;
                        case "Heal":
                            Console.WriteLine(master.Heal(tokens));
                            break;
                        case "EndTurn":
                            Console.WriteLine(master.EndTurn(tokens));
                            break;
                    }

                }
                catch (ArgumentException argex)
                {
                    Console.WriteLine("Parameter Error: " + argex.Message);
                }
                catch (InvalidOperationException invop)
                {
                    Console.WriteLine("Invalid Operation: " + invop.Message);
                }

                input = Console.ReadLine();
                isInputValid = !string.IsNullOrWhiteSpace(input);
                isGameOver = !master.IsGameOver();

            }

            Console.WriteLine("Final stats:");
            Console.WriteLine(master.GetStats());
        }
    }

}