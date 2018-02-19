using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesman
{
    public class CarSalesman
    {
        public static void Main()
        {
            var cars = new List<Car>();
            var engines = new List<Engine>();

            var numberOfEngines = int.Parse(Console.ReadLine());

            for (int counter = 0; counter < numberOfEngines; counter++)
            {
                //engine “<Model> <Power> <Displacement> <Efficiency>
                var tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var model = tokens[0];
                var power = int.Parse(tokens[1]);
                int displacement;
                string efficiency;
                if (tokens.Length == 2)
                {
                    engines.Add(new Engine(model, power));
                }
                else if (tokens.Length == 3)
                {
                    if (int.TryParse(tokens[2], out displacement))
                    {
                        engines.Add(new Engine(model, power, displacement));
                    }
                    else
                    {
                        efficiency = tokens[2];
                        engines.Add(new Engine(model, power, efficiency));
                    }
                }
                else if (tokens.Length == 4)
                {
                    displacement = int.Parse(tokens[2]);
                    efficiency = tokens[3];
                    engines.Add(new Engine(model, power, displacement, efficiency));
                }
            }

            var numberOfCars = int.Parse(Console.ReadLine());

            for (int counter = 0; counter < numberOfCars; counter++)
            {
                //Car “<Model> <Engine> <Weight> <Color>
                var tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var model = tokens[0];
                var engineModel = tokens[1];
                int weight;
                string color;
                if (tokens.Length == 2)
                {
                    cars.Add(new Car(model, engines.FirstOrDefault(e => e.Model.Equals(engineModel))));
                }
                else if (tokens.Length == 3)
                {
                    if (int.TryParse(tokens[2], out weight))
                    {
                        cars.Add(new Car(model, engines.FirstOrDefault(e => e.Model.Equals(engineModel)), weight));
                    }
                    else
                    {
                        color = tokens[2];
                        cars.Add(new Car(model, engines.FirstOrDefault(e => e.Model.Equals(engineModel)), color));
                    }
                }
                else if (tokens.Length == 4)
                {
                    weight = int.Parse(tokens[2]);
                    color = tokens[3];
                    cars.Add(new Car(model, engines.FirstOrDefault(e => e.Model.Equals(engineModel)), weight, color));
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }

        }
    }
}
