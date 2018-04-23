using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Entities;
using DungeonsAndCodeWizards.Entities.Characters;
using DungeonsAndCodeWizards.Entities.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    public class DungeonMaster
    {
        public DungeonMaster()
        {
            this.characterParty = new List<Character>();
            this.items = new Stack<Item>();
            this.lastSurvivorRound = 0;
        }

        private List<Character> characterParty;
        private Stack<Item> items;
        private int lastSurvivorRound;



        public string JoinParty(string[] args)
        {
            string faction = args[0];
            string characterType = args[1];
            string name = args[2];

            object result = null;
            bool parseResult = Enum.TryParse(typeof(Faction), faction, out result);
            if (!parseResult)
            {
                throw new ArgumentException($"Invalid faction \"{faction}\"!");
            }

            switch (characterType.ToLower())
            {
                case "warrior":
                    characterParty.Add(new Warrior(name, (Faction)result));
                    break;
                case "cleric":
                    characterParty.Add(new Cleric(name, (Faction)result));
                    break;
                default:
                    throw new ArgumentException($"Invalid character type \"{ characterType }\"!");
            }

            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            switch (itemName.ToLower())
            {
                case "armorrepairkit":
                    items.Push(new ArmorRepairKit());
                    break;
                case "healthpotion":
                    items.Push(new HealthPotion());
                    break;
                case "poisonpotion":
                    items.Push(new PoisonPotion());
                    break;
                default:
                    throw new ArgumentException($"Invalid item \"{itemName}\"!");
            }

            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            Character character = GetCharacterIfExists(characterName);

            if (items.Count == 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }

            var item = items.Pop();
            character.Bag.AddItem(item);

            return $"{characterName} picked up {item.GetType().Name}!";

        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character character = GetCharacterIfExists(characterName);

            var item = character.Bag.GetItem(itemName);
            character.UseItem(item);

            return $"{character.Name} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = GetCharacterIfExists(giverName);
            Character receiver = GetCharacterIfExists(receiverName);

            var item = giver.Bag.GetItem(itemName);
            giver.UseItemOn(item, receiver);

            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = GetCharacterIfExists(giverName);
            Character receiver = GetCharacterIfExists(receiverName);

            var item = giver.Bag.GetItem(itemName);
            giver.GiveCharacterItem(item, receiver);

            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            string result = string.Empty;
            foreach (var character in this.characterParty.OrderByDescending(c => c.IsAlive).OrderByDescending(c => c.Health))
            {
                string isCharacterAlive = character.IsAlive ? "Alive" : "Dead";
                result += $"{character.Name} - HP: { character.Health}/{ character.BaseHealth}, AP: { character.Armor}/{ character.BaseArmor}, Status: {isCharacterAlive}" + Environment.NewLine;
            }

            return result;
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            Character attackerAsChar = (Warrior)GetCharacterIfExists(attackerName);
            Character receiver = GetCharacterIfExists(receiverName);


            if (!(attackerAsChar is Warrior))
            {
                throw new ArgumentException($"{attackerAsChar.Name} cannot attack!");
            }

            Warrior attacker = (Warrior)attackerAsChar;

            attacker.Attack(receiver);


            string result = $"{ attackerName } attacks { receiverName} for { attacker.AbilityPoints} hit points! " +
                            $"{ receiverName} has { receiver.Health}/{ receiver.BaseHealth} HP and " +
                            $"{ receiver.Armor}/{ receiver.BaseArmor} AP left!";

            if (!receiver.IsAlive)
            {
                result += Environment.NewLine + $"{receiver.Name} is dead!";
            }

            return result;
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            Character healerAsChar = (Cleric)GetCharacterIfExists(healerName);
            Character receiver = GetCharacterIfExists(healingReceiverName);

            if (!(healerAsChar is Cleric))
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }

            Cleric healer = (Cleric)healerAsChar;

            healer.Heal(receiver);

            string result = $"{ healer.Name } heals { receiver.Name} for { healer.AbilityPoints}! { receiver.Name} has { receiver.Health} health now!";
            return result;
        }

        public string EndTurn(string[] args)
        {
            string result = "";
            foreach (var character in this.characterParty.Where(c => c.IsAlive))
            {
                double healthBeforeRest = character.Health;
                character.Rest();
                double currentHealth = character.Health;
                result += $"{character.Name} rests ({healthBeforeRest} => {currentHealth})" + Environment.NewLine;
            }

            if (this.characterParty.Count(c => c.IsAlive) <= 1)
            {
                this.lastSurvivorRound++;
            }
            return result.TrimEnd();
        }

        public bool IsGameOver()
        {
            if (lastSurvivorRound > 1)
            {
                return true;
            }
            return false;
        }

        private Character GetCharacterIfExists(string characterName)
        {
            var character = this.characterParty.FirstOrDefault(c => c.Name == characterName);
            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            return character;
        }

    }
}
