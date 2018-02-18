using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedRacing
{
    public class Car
    {
        //model, fuel amount, fuel consumption for 1 kilometer and distance traveled

        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKm;
        private int distanceTravelled;

        public Car(string model, double fuelAmount, double fuelConsumptionPerKm)
        {
            this.model = model;
            this.fuelAmount = fuelAmount;
            this.fuelConsumptionPerKm = fuelConsumptionPerKm;
            this.distanceTravelled = 0;
        }

        public int DistanceTravelled
        {
            get { return distanceTravelled; }
            set { distanceTravelled = value; }
        }


        public double FuelConsumptionPerKm
        {
            get { return fuelConsumptionPerKm; }
            //set { fuelConsumptionPerKm = value; }
        }


        public double FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }


        public string Model
        {
            get { return model; }
            //set { model = value; }
        }

        public bool CanCarMove(int distance)
        {
            if (distance * FuelConsumptionPerKm > FuelAmount)
            {
                return false;
            }
            return true;
        }

        public override string ToString()
        {
            return $"{Model} {FuelAmount:F2} {DistanceTravelled}";
        }
    }
}
