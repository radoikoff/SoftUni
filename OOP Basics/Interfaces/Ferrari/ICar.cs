using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface ICar
{
    string Model { get; }
    string DriverName { get; }
    string PushGas();
    string PushBrake();
}

