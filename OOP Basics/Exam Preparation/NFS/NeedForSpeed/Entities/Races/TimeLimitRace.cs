using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class TimeLimitRace : Race
{
    private int goldTime;

    public TimeLimitRace(int length, string route, int prizePool, int goldTime)
        : base(length, route, prizePool)
    {
        this.goldTime = goldTime;
    }

    public override int GetPerformance(int carId)
    {
        var car = Participants.FirstOrDefault().Value;
        return this.Length * ((car.Horsepower / 100) * car.Acceleration);
    }

    public override void AddCar(int carId, Car car)
    {
        if (this.Participants.Count == 0)
        {
            base.Participants.Add(carId, car);
        }
    }

    private string GetEarnedTime(int timePerformance)
    {
        if (timePerformance <= this.goldTime)
        {
            return "Gold";
        }
        else if (timePerformance <= this.goldTime + 15)
        {
            return "Silver";
        }
        else
        {
            return "Bronze";
        }
    }

    private int GetPrize(int timePerformance)
    {
        if (timePerformance <= this.goldTime)
        {
            return base.PrizePool;
        }
        else if (timePerformance <= this.goldTime + 15)
        {
            return base.PrizePool * 50 / 100;
        }
        else
        {
            return base.PrizePool * 30 / 100;
        }
    }

    public override string StartRace()
    {
        StringBuilder sb = new StringBuilder();
        var carId = Participants.FirstOrDefault().Key;
        var car = Participants.FirstOrDefault().Value;
        var prizes = GetPrizes();
        var timePerformance = GetPerformance(carId);
        var participantEarnedTime = GetEarnedTime(timePerformance);
        var prize = GetPrize(timePerformance);

        sb.AppendLine($"{this.Route} - {this.Length}");
        sb.AppendLine($"{car.Brand} { car.Model} – { this.GetPerformance(carId)} s.");
        sb.AppendLine($"{participantEarnedTime} Time, ${prize}.");

        return sb.ToString().Trim();
    }
}

