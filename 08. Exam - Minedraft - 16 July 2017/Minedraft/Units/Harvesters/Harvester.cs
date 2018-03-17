using System;
using System.Collections.Generic;
using System.Text;

public abstract class Harvester : MiningUnit
{
    private const string EnergyRequirementException = "Harvester is not registered, because of it's EnergyRequirement";
    private const string OreOutputException = "Harvester is not registered, because of it's OreOutput";
    
    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement) : base(id)
    {
        this.Id = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public double EnergyRequirement
    {
        get { return energyRequirement; }
        protected set
        {
            if (value < 0 || value > 20000)
            {
                throw new ArgumentException(EnergyRequirementException);
            }

            this.energyRequirement = value;
        }
    }

    public double OreOutput
    {
        get { return oreOutput; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException(OreOutputException);
            }
            oreOutput = value;
        }
    }

    public override string ToString()
    {
        //    //{type} Harvester – {id}
        //    //Ore Output: {oreOutput}
        //    //Energy Requirement: {energyRequired}

        var sb = new StringBuilder();
        sb.AppendLine($"Harvester - {this.Id}");
        sb.AppendLine($"Ore Output: {this.OreOutput}");
        sb.AppendLine($"Energy Requirement: {this.EnergyRequirement}");

        return sb.ToString().Trim();
    }
}
