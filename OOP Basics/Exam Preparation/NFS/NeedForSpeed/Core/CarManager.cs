using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class CarManager
{
    public CarManager()
    {
        this.cars = new Dictionary<int, Car>();
        this.races = new Dictionary<int, Race>();
        this.garage = new Garage();
        this.closedRaces = new List<int>();
    }

    private Dictionary<int, Car> cars;
    private Dictionary<int, Race> races;
    private Garage garage;
    private List<int> closedRaces;


    public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        if (!cars.ContainsKey(id))
        {
            switch (type)
            {
                case "Performance":
                    var perfCar = new PerformanceCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
                    cars.Add(id, perfCar);
                    break;
                case "Show":
                    var showCar = new ShowCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability, 0);
                    cars.Add(id, showCar);
                    break;
            }
        }

    }

    public string Check(int id)
    {
        return cars[id].ToString();
    }

    public void Open(int id, string type, int length, string route, int prizePool)
    {
        if (!races.ContainsKey(id))
        {
            switch (type)
            {
                case "Casual":
                    races.Add(id, new CasualRace(length, route, prizePool));
                    break;
                case "Drag":
                    races.Add(id, new DragRace(length, route, prizePool));
                    break;
                case "Drift":
                    races.Add(id, new DriftRace(length, route, prizePool));
                    break;
            }
        }
    }

    public void Open(int id, string type, int length, string route, int prizePool, int extraArg)
    {
        if (!races.ContainsKey(id))
        {
            switch (type)
            {
                case "TimeLimit":
                    races.Add(id, new TimeLimitRace(length, route, prizePool, extraArg));
                    break;
                case "Circuit":
                    races.Add(id, new CircuitRace(length, route, prizePool, extraArg));
                    break;
            }
        }
    }

    public void Participate(int carId, int raceId)
    {
        if (races.ContainsKey(raceId) && !garage.ParkedCars.Contains(carId) && !closedRaces.Contains(raceId))
        {
            races[raceId].AddCar(carId, cars[carId]);
        }
    }

    public string Start(int id)
    {
        string result = "";
        if (!closedRaces.Contains(id))
        {
            if (races[id].Participants.Any())
            {
                closedRaces.Add(id);
                result = races[id].StartRace();
            }
            else
            {
                result = "Cannot start the race with zero participants.";
            }

        }
        return result;


    }

    public void Park(int id)
    {
        if (!races.Where(r => !closedRaces.Contains(r.Key)).Any(r => r.Value.Participants.ContainsKey(id)))
        {
            garage.AddCar(id);
        }
    }

    public void Unpark(int id)
    {
        garage.RemoveCar(id);
    }

    public void Tune(int tuneIndex, string addOn)
    {
        if (garage.ParkedCars.Any())
        {
            foreach (var carId in garage.ParkedCars)
            {
                cars[carId].Tune(tuneIndex, addOn);
            }
        }
    }


}

