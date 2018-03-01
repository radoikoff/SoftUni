using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Dough
    {
        private const double ModifierWhite = 1.5;
        private const double ModifierWholegrain = 1.0;
        private const double ModifierCrispy = 0.9;
        private const double ModifierChewy = 1.1;
        private const double ModifierHomemade = 1.0;

        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public int Weight
        {
            get { return weight; }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentOutOfRangeException("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }

        public string BakingTechnique
        {
            get { return bakingTechnique; }
            private set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentOutOfRangeException("Invalid type of dough.");
                }
                bakingTechnique = value;
            }
        }

        public string FlourType
        {
            get { return flourType; }
            private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentOutOfRangeException("Invalid type of dough.");
                }
                flourType = value;
            }
        }

        public double GetCaloriesPerGram()
        {
            double modifier = 0;
            if (flourType.ToLower() == "white")
            {
                modifier = 1.5;
            }
            else if (flourType.ToLower() == "wholegrain")
            {
                modifier = 1.0;
            }


            if (bakingTechnique.ToLower() == "crispy")
            {
                modifier *= 0.9;
            }
            else if (bakingTechnique.ToLower() == "chewy")
            {
                modifier *= 1.1;
            }
            else if (bakingTechnique.ToLower() == "homemade")
            {
                modifier *= 1.0;
            }

            return weight * 2 * modifier;
        }

    }
}
