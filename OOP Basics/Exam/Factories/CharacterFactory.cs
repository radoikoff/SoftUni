using DungeonsAndCodeWizards.Entities;
using DungeonsAndCodeWizards.Entities.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Factories
{
    public class CharacterFactory
    {
        public Character CreateCharacter(string name, string faction, string type)
        {
            object result = null;
            bool parseResult = Enum.TryParse(typeof(Faction), faction, out result);
            if (!parseResult)
            {
                throw new ArgumentException($"Invalid faction \"{faction}\"!");
            }

            switch (type.ToLower())
            {
                case "warrior":
                    return new Warrior(name, (Faction)result);
                case "cleric":
                    return new Cleric(name, (Faction)result);
                default:
                    throw new ArgumentException($"Invalid character type \"{ type }\"!");
            }
        }
    }
}
