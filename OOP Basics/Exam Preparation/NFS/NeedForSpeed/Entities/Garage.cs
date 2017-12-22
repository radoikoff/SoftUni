using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Garage
{
    private List<int> parkedCars;

    public Garage()
    {
        this.parkedCars = new List<int>();
    }

    public IReadOnlyList<int> ParkedCars
    {
        get { return parkedCars.AsReadOnly(); }
    }

    public void RemoveCar(int id)
    {
        if (this.parkedCars.Contains(id))
        {
            this.parkedCars.Remove(id);
        };
    }

    internal void AddCar(int id)
    {
        if (!this.parkedCars.Contains(id))
        {
            this.parkedCars.Add(id);
        };
    }
}
