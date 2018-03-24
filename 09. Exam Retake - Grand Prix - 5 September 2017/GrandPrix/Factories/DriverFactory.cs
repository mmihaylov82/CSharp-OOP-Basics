using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class DriverFactory
{
    public static Driver CreateDriver(List<string> commandArgs)
    {
        Driver driver;

        var driverType = commandArgs[0];
        var name = commandArgs[1];
        var hp = int.Parse(commandArgs[2]);
        var fuelAmount = double.Parse(commandArgs[3]);

        var tyreArgs = commandArgs.Skip(4).ToList();
        var tyre = TyreFactory.CreateTyre(tyreArgs);

        Car car = new Car(hp, fuelAmount, tyre);

        if (driverType == "Aggressive")
        {
            driver = new AggressiveDriver(name, car);
        }
        else if (driverType == "Endurance")
        {
            driver = new EnduranceDriver(name, car);
        }
        else
        {
            throw new ArgumentException();
        }

        return driver;
    }
}

