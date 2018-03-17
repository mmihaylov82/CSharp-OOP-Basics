using System;
using System.Collections.Generic;
using System.Text;

public abstract class Provider : MiningUnit
{
    private const string energyOutputException = "Provider is not registered, because of it's EnergyOutput";

    private double energyOutput;

    protected Provider(string id, double energyOutput) : base(id)
    {
        this.EnergyOutput = energyOutput;
    }
    
    public double EnergyOutput
    {
        get { return energyOutput; }
        protected set
        {
            if (value < 0 || value > 10000)
            {
                throw new ArgumentException(energyOutputException);
            }
            energyOutput = value;
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Provider - {this.Id}");
        sb.AppendLine($"Energy Output: {this.energyOutput}");

        return sb.ToString().Trim();
    }
}
