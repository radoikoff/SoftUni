using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class AddCollection<T> : IAddCollection<T>
{
    public AddCollection()
    {
        this.data = new List<T>();
    }

    protected List<T> data;

    public virtual int Add(T element)
    {
        data.Add(element);
        return data.Count - 1;
    }
}

