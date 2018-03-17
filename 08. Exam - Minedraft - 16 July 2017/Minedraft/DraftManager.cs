using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private SystemMode systemMode;
    public double TotalStoredEnergy { get; private set; }
    public double TotalMinedOre { get; private set; }
    private Dictionary<string, Harvester> harvesters;
    private Dictionary<string, Provider> providers;
    private Dictionary<string, MiningUnit> miningUnits;

    public DraftManager()
    {
        this.systemMode = SystemMode.Full;
        this.TotalStoredEnergy = 0d;
        this.TotalMinedOre = 0d;
        this.harvesters = new Dictionary<string, Harvester>();
        this.providers = new Dictionary<string, Provider>();
        this.miningUnits = new Dictionary<string, MiningUnit>();
    }

    public string RegisterHarvester(List<string> arguments)
    {
        //•	RegisterHarvester Sonic {id} {oreOutput} {energyRequirement} {sonicFactor}
        try
        {
            var id = arguments[1];
            var harvester = HarvesterFactory.CreateHarvester(arguments);
            harvesters.Add(id, harvester);
            miningUnits.Add(id, harvester);

            return $"Successfully registered {arguments[0]} Harvester - {id}";
        }
        catch (ArgumentException ex)
        {
            return $"{ex.Message}";
        }
    }

    public string RegisterProvider(List<string> arguments)
    {
        //•	RegisterProvider {type} {id} {energyOutput}
        try
        {
            var id = arguments[1];
            var provider = ProviderFactory.CreateProvider(arguments);
            providers.Add(id, provider);
            miningUnits.Add(id, provider);

            return $"Successfully registered {arguments[0]} Provider - {id}";
        }
        catch (ArgumentException ex)
        {
            return $"{ex.Message}";
        }
    }

    public string Day()
    {
        double orePerDay = 0;
        double harvestersNeededEnergyPerDay = 0;
        double energyPerDay = providers.Values.Sum(p => p.EnergyOutput);

        TotalStoredEnergy += energyPerDay;

        harvestersNeededEnergyPerDay += harvesters.Values.Sum(p => p.EnergyRequirement);

        if (TotalStoredEnergy >= harvestersNeededEnergyPerDay)
        {
            if (systemMode == SystemMode.Full)
            {
                orePerDay += harvesters.Values.Sum(p => p.OreOutput);
                TotalStoredEnergy -= harvestersNeededEnergyPerDay;
            }
            else if (systemMode == SystemMode.Half)
            {
                orePerDay += harvesters.Values.Sum(p => p.OreOutput * 0.5);
                TotalStoredEnergy -= harvestersNeededEnergyPerDay * 0.6;
            }

            TotalMinedOre += orePerDay;
        }

        var sb = new StringBuilder();
        sb.AppendLine("A day has passed.");
        sb.AppendLine($"Energy Provided: {energyPerDay}");
        sb.AppendLine($"Plumbus Ore Mined: {orePerDay}");
        return sb.ToString().Trim();
    }

    public string Mode(List<string> arguments)
    {
        var mode = arguments[0];
        this.systemMode = (SystemMode)Enum.Parse(typeof(SystemMode), mode);

        return $"Successfully changed working mode to {mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        var id = arguments[0];

        if (miningUnits.ContainsKey(id))
        {
            var wantedMiningUnit = miningUnits.Values.FirstOrDefault(u => u.Id == id);
            return wantedMiningUnit.ToString();
        }
        else
        {
            return $"No element found with id - {id}";
        }
    }

    public string ShutDown()
    {
        var sb = new StringBuilder();
        sb.AppendLine("System Shutdown")
            .AppendLine($"Total Energy Stored: {this.TotalStoredEnergy}")
            .AppendLine($"Total Mined Plumbus Ore: {this.TotalMinedOre}");
        
        return sb.ToString().Trim();
    }

}

