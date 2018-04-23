using DungeonsAndCodeWizards.Entities.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Factories
{
    public class ItemFactory
    {
        public Item CreateItem(string itemName)
        {
            switch (itemName.ToLower())
            {
                case "armorrepairkit":
                    return new ArmorRepairKit();
                case "healthpotion":
                    return new HealthPotion();
                case "poisonpotion":
                    return new PoisonPotion();
                default:
                    throw new ArgumentException($"Invalid item \"{itemName}\"!");
            }
        }
    }
}
