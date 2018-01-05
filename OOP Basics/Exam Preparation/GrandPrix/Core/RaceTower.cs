using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class RaceTower
{
    private List<Driver> drivers;
    private Dictionary<string, string> failedDrivers;
    private int lapsNumber;
    private int trackLength;
    private string weather = "Sunny";

    public RaceTower()
    {
        List<Driver> drivers = new List<Driver>();
        Dictionary<string, string> failedDrivers = new Dictionary<string, string>();
    }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.lapsNumber = lapsNumber;
        this.trackLength = trackLength;
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        //RegisterDriver {type} {name} {hp} {fuelAmount} Ultrasoft {tyreHardness} {grip}
        if (IsCmdArgsValid(commandArgs))
        {
            string type = commandArgs[0];
            string name = commandArgs[1];
            int hp = int.Parse(commandArgs[2]);
            double fuelAmount = double.Parse(commandArgs[3]);
            string tyreType = commandArgs[4];
            double tyreHardness = double.Parse(commandArgs[5]);

            Tyre tyre = null;
            Car car = null;
            Driver driver = null;

            try
            {
                if (tyreType == "Hard")
                {
                    tyre = new HardTyre(tyreHardness);
                }
                else if (tyreType == "Ultrasoft")
                {
                    double tyreGrip = double.Parse(commandArgs[6]);
                    tyre = new UltrasoftTyre(tyreHardness, tyreGrip);
                }
            }
            catch (Exception)
            {
            }

            if (tyre != null)
            {
                try
                {
                    car = new Car(hp, fuelAmount, tyre);
                }
                catch (Exception)
                {
                }
            }

            if (car != null)
            {
                try
                {
                    if (type == "Aggressive")
                    {
                        driver = new AggressiveDriver(name, car);
                    }
                    else if (type == "Endurance")
                    {
                        driver = new EnduranceDriver(name, car);
                    }
                }
                catch (Exception)
                {
                }
            }

            if (driver != null)
            {
                if (!drivers.Any(d => d.Name.Equals(name)))
                {
                    drivers.Add(driver);
                }
            }

        }

    }

    public void DriverBoxes(List<string> commandArgs)
    {
        //TODO: Add some logic here …
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        StringBuilder sb = new StringBuilder();
        int numberOfLaps = int.Parse(commandArgs[0]);

        if (numberOfLaps > lapsNumber)
        {
            return $"There is no time! On lap {lapsNumber}.";
        }

        while (lapsNumber > lapsNumber - numberOfLaps)
        {
            foreach (var driver in drivers)
            {
                driver.TotalTime += 60 / (trackLength / driver.Speed);
                try
                {
                    driver.Car.FuelAmount -= trackLength * driver.FuelConsumptionPerKm;
                    driver.Car.Tyre.SetDegradation();
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    drivers.Remove(driver);
                    failedDrivers.Add(driver.Name, ex.Message);
                }
            }

            //overtaking 
            drivers.OrderByDescending(d => d.TotalTime);
            for (int i = 0; i < drivers.Count - 1; i++)
            {
                var currentDriver = drivers[i];
                var nextDriver = drivers[i + 1];
                if (currentDriver.TotalTime - nextDriver.TotalTime <= currentDriver.GetOvertakeTime())
                {
                    currentDriver.TotalTime -= 2;
                    nextDriver.TotalTime += 2;

                    if (currentDriver.GetCrashedDuringOvertake(weather))
                    {
                        drivers.Remove(currentDriver);
                        failedDrivers.Add(currentDriver.Name, "Crashed");
                    }

                    //what to do with nextDriver? to remove?
                }
            }

            lapsNumber--;
        }

        return "";
    }

    public string GetLeaderboard()
    {
        return "";
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        //TODO: Add some logic here …
    }

    private bool IsCmdArgsValid(List<string> commandArgs)
    {
        bool result = true;
        if (commandArgs.Count == 6)
        {
            try
            {
                int hp = int.Parse(commandArgs[2]);
                double fuelAmount = double.Parse(commandArgs[3]);
                double tyreHardness = double.Parse(commandArgs[5]);
            }
            catch (Exception)
            {
                result = false;
            }
        }

        if (commandArgs.Count == 7)
        {
            try
            {
                double tyreGrip = double.Parse(commandArgs[6]);
            }
            catch (Exception)
            {
                result = false;
            }

        }

        return result;
    }
}

