using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Robot : Inhabitant
{
    public Robot(string model, string id)
        : base(id)
    {
        Model = model;
    }

    public string Model { get; private set; }
}
