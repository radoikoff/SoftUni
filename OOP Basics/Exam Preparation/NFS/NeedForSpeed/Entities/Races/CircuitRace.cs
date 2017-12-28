using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CircuitRace : Race
{
    public CircuitRace(int length, string route, int prizePool, int laps)
        : base(length, route, prizePool)
    {
        this.laps = laps;
    }

    private int laps;

    public int Laps
    {
        get { return laps; }
        set { laps = value; }
    }


    public override int GetPerformance(int carId)
    {

        var car = Participants[carId];
        return (car.Horsepower / car.Acceleration) + (car.Suspension + car.Durability);
    }

    protected override List<int> GetPrizes()
    {
        var prizes = new List<int>();
        prizes.Add(base.PrizePool * 40 / 100);
        prizes.Add(base.PrizePool * 30 / 100);
        prizes.Add(base.PrizePool * 20 / 100);
        prizes.Add(base.PrizePool * 10 / 100);

        return prizes;
    }

    public override string StartRace()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.Route} - {this.Length * laps}");

        foreach (var participant in this.Participants.Values)
        {
            participant.Durability -= laps * Length * Length;
        }

        var winners = this.Participants.OrderByDescending(p => p.Value.OverallPerformance()).Take(4).ToDictionary(k => k.Key, v => v.Value);
        var prizes = GetPrizes();

        for (int i = 0; i < winners.Count; i++)
        {
            var car = winners.ElementAt(i);
            sb.AppendLine($"{i + 1}. {car.Value.Brand} {car.Value.Model} {this.GetPerformance(car.Key)}PP - ${prizes[i]}");
        }

        return sb.ToString().Trim();
    }
}
