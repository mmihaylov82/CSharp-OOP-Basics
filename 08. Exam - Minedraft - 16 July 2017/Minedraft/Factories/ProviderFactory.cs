using System;
using System.Collections.Generic;
using System.Text;

public static class ProviderFactory
{
    public static Provider CreateProvider(List<string> commandArgs)
    {
        var type = commandArgs[0];
        var id = commandArgs[1];
        var energyOutput = double.Parse(commandArgs[2]);
        switch (type)
        {
            case "Solar":
                return new SolarProvider(id, energyOutput);
            case "Pressure":
                return new PressureProvider(id, energyOutput);
            default:
                throw new ArgumentException();
        }
    }
}

