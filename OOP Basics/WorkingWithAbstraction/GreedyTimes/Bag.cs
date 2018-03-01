using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyTimes
{
    class Bag
    {
        private Dictionary<string, long> cash;
        private Dictionary<string, long> gems;
        private long gold;


        public Bag()
        {
            gems = new Dictionary<string, long>();
            cash = new Dictionary<string, long>();
        }

        public long BagCurrentAmount
        {
            get
            {
                return gems.Values.Sum() + cash.Values.Sum() + gold;
            }
        }



        public void AddGem(string name, long amount)
        {
            if (gold >= gems.Values.Sum() + amount && gems.Values.Sum() + amount  >= cash.Values.Sum())
            {
                if (!gems.ContainsKey(name))
                {
                    gems.Add(name, 0);
                }

                gems[name] += amount;
            }


        }

        public void AddCash(string name, long amount)
        {
            if (!cash.ContainsKey(name))
            {
                cash.Add(name, 0);
            }

            cash[name] += amount;
        }

        public void AddGold(long amount)
        {
            if (gold + amount >= gems.Values.Sum())
            {
                gold += amount;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"<Gold> ${gold}");
            sb.AppendLine($"##Gold - {gold}");
            sb.AppendLine($"<Gem> ${gems.Values.Sum()}");
            foreach (var gem in gems)
            {
                sb.AppendLine($"##{gem.Key} - {gems.Values.Sum()}");
            }
            sb.AppendLine($"<Cash> ${cash.Values.Sum()}");
            foreach (var item in cash)
            {
                sb.AppendLine($"##{item.Key} - {cash.Values.Sum()}");
            }

            return sb.ToString();
        }

    }
}
