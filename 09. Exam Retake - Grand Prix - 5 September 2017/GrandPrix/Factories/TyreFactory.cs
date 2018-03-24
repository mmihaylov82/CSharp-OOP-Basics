using System;
using System.Collections.Generic;

public static class TyreFactory
{
    public static Tyre CreateTyre(List<string> tyreArgs)
    {
        var tyreType = tyreArgs[0];
        var tyreHardness = double.Parse(tyreArgs[1]);

        if (tyreType == "Ultrasoft")
        {
            var grip = double.Parse(tyreArgs[2]);
            return new UltrasoftTyre(tyreHardness, grip);
        }

        return new HardTyre(tyreHardness);
    }
}