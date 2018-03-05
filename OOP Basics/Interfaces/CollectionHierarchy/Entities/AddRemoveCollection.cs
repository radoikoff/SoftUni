using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class AddRemoveCollection<T> : AddCollection<T>, IAddRemoveCollection<T>
{
    public override int Add(T element)
    {
        base.data.Insert(0, element);
        return 0;
    }

    public virtual T Remove()
    {
        int indexToRemove = data.Count - 1;
        var elementToRemove = data[indexToRemove];
        data.RemoveAt(indexToRemove);
        return elementToRemove;
    }
}

