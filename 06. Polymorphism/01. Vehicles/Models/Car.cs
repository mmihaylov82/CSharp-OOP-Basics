using System;
using System.Collections.Generic;
using System.Text;

public class Car : IVehicle
{
    private double fuelQuantity;
    private double fuelConsumption;

    public Car(double fuelQuantity, double fuelConsumption)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumption = fuelConsumption + 0.9;
    }

    public double FuelQuantity
    {
        get { return fuelQuantity; }
        set { fuelQuantity = value; }
    }

    public double FuelConsumption
    {
        get { return fuelConsumption; }
        set { fuelConsumption = value; }
    }

    public void Drive(double distance)
    {
        var neededFuel = distance * this.FuelConsumption;

        if (neededFuel < this.FuelQuantity)
        {
            this.FuelQuantity -= neededFuel;
            Console.WriteLine($"{ this.GetType().Name} travelled {distance} km");
        }
        else
        {
            Console.WriteLine($"{ this.GetType().Name} needs refueling");
        }
    }

    public void Refuel(double quantity)
    {
        this.FuelQuantity += quantity;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
    }
}

