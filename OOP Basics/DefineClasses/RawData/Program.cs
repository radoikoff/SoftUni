using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawData
{
    public class Program
    {
        public static void Main()
        {
            var cars = new List<Car>();
            var number = int.Parse(Console.ReadLine());

            for (int counter = 0; counter < number; counter++)
            {
                var tokens = Console.ReadLine().Split();
                var model = tokens[0];
                var engineSpeed = int.Parse(tokens[1]);
                var enginePower = int.Parse(tokens[2]);
                var cargoWeight = int.Parse(tokens[3]);
                var cargoType = tokens[4];
                //var tyre1Pressure = double.Parse(tokens[5]);
                //var tyre1Age = int.Parse(tokens[6]);

                var tyres = new List<Tyre>();
                for (int i = 0; i < 8; i += 2)
                {
                    tyres.Add(new Tyre(int.Parse(tokens[6 + i]), double.Parse(tokens[5 + i])));
                }

                var cargo = new Cargo(cargoWeight, cargoType);
                var engine = new Engine(engineSpeed, enginePower);

                cars.Add(new Car(model, engine, cargo, tyres));
            }

            var command = Console.ReadLine();
            if (command == "fragile")
            {
                foreach (var car in cars.Where(c => c.Cargo.Type.Equals("fragile")).Where(c => c.Tyres.Any(t => t.Pressure < 1)))
                {
                    Console.WriteLine(car.Model);
                }
            }
            else if (command == "flamable")
            {
                foreach (var car in cars.Where(c => c.Cargo.Type.Equals("flamable")).Where(c => c.Engine.Power > 250))
                {
                    Console.WriteLine(car.Model);
                }
            }

        }
    }
}
