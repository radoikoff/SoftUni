using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;
        //private int numberOfToppings;

        public Pizza()
        {
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentOutOfRangeException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }

        public Dough Dough
        {
            get { return dough; }
            set { dough = value; }
        }

        public void AddToping(Topping topping)
        {
            if (toppings.Count > 10)
            {
                throw new ArgumentOutOfRangeException("Number of toppings should be in range [0..10].");
            }
            toppings.Add(topping);
        }

        public double GetTotalCalories()
        {

            return dough.GetCaloriesPerGram() + ((toppings.Count != 0) ? this.toppings.Sum(t => t.GetCaloriesPerGram()) : 0);
        }

    }
}
