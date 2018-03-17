using System;
using System.Collections.Generic;
using System.Text;

public class SonicHarvester : Harvester
{
    private int sonicFactor;

    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor) 
        : base(id, oreOutput, energyRequirement)
    {
        this.EnergyRequirement = energyRequirement / sonicFactor;
    }

    public override string ToString()
    {
        //{type} Harvester – {id}
        //Ore Output: {oreOutput}
        //Energy Requirement: {energyRequired}

        return $"Sonic {base.ToString().Trim()}";
    }
}

