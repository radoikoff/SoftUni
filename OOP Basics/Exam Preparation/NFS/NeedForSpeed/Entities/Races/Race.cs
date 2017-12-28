using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Race
{
    private int length;
    private string route;
    private int prizePool;
    private Dictionary<int, Car> participants;

    public Race(int length, string route, int prizePool)
    {
        this.length = length;
        this.route = route;
        this.prizePool = prizePool;
        this.participants = new Dictionary<int, Car>();
    }

    public int Length
    {
        get
        {
            return length;
        }

        set
        {
            length = value;
        }
    }

    public string Route
    {
        get
        {
            return route;
        }

        set
        {
            route = value;
        }
    }

    public int PrizePool
    {
        get
        {
            return prizePool;
        }

        set
        {
            prizePool = value;
        }
    }

    public Dictionary<int, Car> Participants
    {
        get { return participants; }
    }

    public virtual void AddCar(int carId, Car car)
    {
        if (!this.participants.ContainsKey(carId))
        {
            participants.Add(carId, car);
        }
    }

    public abstract int GetPerformance(int carId);

    protected virtual List<int> GetPrizes()
    {
        var prizes = new List<int>();
        prizes.Add(this.prizePool * 50 / 100);
        prizes.Add(this.prizePool * 30 / 100);
        prizes.Add(this.prizePool * 20 / 100);

        return prizes;
    }

    public virtual string StartRace()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.route} - {this.length}");

        var winners = this.participants.OrderByDescending(p => p.Value.OverallPerformance()).Take(3).ToDictionary(k => k.Key, v => v.Value);
        var prizes = GetPrizes();

        for (int i = 0; i < winners.Count; i++)
        {
            var car = winners.ElementAt(i);
            sb.AppendLine($"{i + 1}. {car.Value.Brand} {car.Value.Model} {this.GetPerformance(car.Key)}PP - ${prizes[i]}");
        }

        return sb.ToString().Trim();
    }

}

