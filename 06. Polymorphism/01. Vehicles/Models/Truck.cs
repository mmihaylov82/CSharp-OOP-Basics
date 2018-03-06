using System;
using System.Collections.Generic;
using System.Text;

public class Truck : IVehicle
{
    private double fuelQuantity;
    private double fuelConsumption;

    public Truck(double fuelQuantity, double fuelConsumption)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumption = fuelConsumption + 1.6;
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
        this.FuelQuantity += quantity * 0.95;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
    }
}

