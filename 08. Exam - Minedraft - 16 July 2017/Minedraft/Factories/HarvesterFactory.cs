using System;
using System.Collections.Generic;
using System.Text;

public static class HarvesterFactory
{
    public static Harvester CreateHarvester(List<string> commandArgs)
    {
        //•	RegisterHarvester {type} {id} {oreOutput} {energyRequirement}
        //•	RegisterHarvester Sonic {id} {oreOutput} {energyRequirement} {sonicFactor}

        var type = commandArgs[0];
        var id = commandArgs[1];
        var oreOutput = double.Parse(commandArgs[2]);
        var energyRequirement = double.Parse(commandArgs[3]);

        switch (type)
        {
            case "Hammer":
                return new HammerHarvester(id, oreOutput, energyRequirement);
            case "Sonic":
                var sonicFactor = int.Parse(commandArgs[4]);
                return new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);
            default:
                throw new ArgumentException();
        }
    }
}

