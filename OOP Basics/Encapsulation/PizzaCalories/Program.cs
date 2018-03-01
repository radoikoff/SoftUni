using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Program
    {
        public static void Main()
        {


            var pizzaName = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Skip(1).First();
            var pizza = new Pizza();
            try
            {
                pizza.Name = pizzaName;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.ParamName);
                return;
            }



            var doughData = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
            var flour = doughData[0];
            var baking = doughData[1];
            var weight = int.Parse(doughData[2]);

            try
            {
                var dough = new Dough(flour, baking, weight);
                pizza.Dough = dough;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.ParamName);
                return;
            }



            string toppingInput;
            while ((toppingInput = Console.ReadLine()) != "END")
            {
                var toppingData = toppingInput.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
                var toppingName = toppingData[0];
                var toppingWeight = int.Parse(toppingData[1]);

                try
                {
                    var topping = new Topping(toppingName, toppingWeight);
                    pizza.AddToping(topping);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.ParamName);
                    return;
                }
            }

            Console.WriteLine($"{pizza.Name} - {pizza.GetTotalCalories():F2} Calories.");

        }
    }
}
