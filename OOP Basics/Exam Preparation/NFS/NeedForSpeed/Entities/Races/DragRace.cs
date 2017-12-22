﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class DragRace : Race
{
    public DragRace(int length, string route, int prizePool) : base(length, route, prizePool)
    {
    }

    public override int GetPerformance(int carId)
    {
        var car = Participants[carId];
        return (car.Horsepower / car.Acceleration);
    }
}

