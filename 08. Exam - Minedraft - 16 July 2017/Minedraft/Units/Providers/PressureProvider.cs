using System;
using System.Collections.Generic;
using System.Text;

public class PressureProvider : Provider
{
    public PressureProvider(string id, double energyOutput) 
        : base(id, energyOutput)
    {
        this.EnergyOutput = energyOutput * 1.5;
    }

    public override string ToString()
    {
        //{type} Provider – {id}
        //Energy Output: {energyOutput}

        return $"Pressure {base.ToString().Trim()}";
    }
}

