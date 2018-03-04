using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Inhabitant
{
    public Inhabitant(string id)
    {
        Id = id;
    }

    public string Id { get; private set; }
}

