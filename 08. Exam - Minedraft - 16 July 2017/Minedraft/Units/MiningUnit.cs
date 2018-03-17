using System;
using System.Collections.Generic;
using System.Text;

public abstract class MiningUnit
{
    private string id;

    public string Id
    {
        get { return id; }
        protected set { id = value; }
    }

    protected MiningUnit(string id)
    {
        this.Id = id;
    }

    public override string ToString()
    {
        return base.ToString();
    }
}

