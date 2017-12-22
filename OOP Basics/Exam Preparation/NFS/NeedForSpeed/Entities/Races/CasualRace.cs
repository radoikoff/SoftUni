using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CasualRace : Race
{
    public CasualRace(int length, string route, int prizePool) : base(length, route, prizePool)
    {
    }

    public override int GetPerformance(int carId)
    {
        var car = Participants[carId];
        return (car.Horsepower / car.Acceleration) + (car.Suspension + car.Durability);
    }


}

