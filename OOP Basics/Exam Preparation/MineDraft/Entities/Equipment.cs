using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Equipment
{
    private string id;

    protected Equipment(string id)
    {
        this.Id = id;
    }

    public string Id
    {
        get { return id; }
        protected set { id = value; }
    }
}
