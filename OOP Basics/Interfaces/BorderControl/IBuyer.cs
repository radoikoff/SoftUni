﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IBuyer : IDescribable
{
    int Food { get; }
    void BuyFood();
}