using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class MyList<T> : AddRemoveCollection<T>, IMyList<T>
{
    public int Used
    {
        get { return data.Count; }
    }

    public override T Remove()
    {
        var elementToRemove = data[0];
        data.RemoveAt(0);
        return elementToRemove;
    }
}

