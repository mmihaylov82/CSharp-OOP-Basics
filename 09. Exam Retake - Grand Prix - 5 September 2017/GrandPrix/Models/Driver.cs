using System;
using System.Collections.Generic;
using System.Text;

public abstract class Driver
{
    public string Name { get; private set; }

    public double TotalTime { get; set; }

    public Car Car { get; private set; }

    public double FuelConsumptionPerKm { get; protected set; }

    public virtual double Speed => (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;

    protected Driver(string name, Car car, double fuelComsumption)
    {
        this.Name = name;
        this.Car = car;
        this.TotalTime = 0;
        this.FuelConsumptionPerKm = fuelComsumption;
    }

    public virtual void ReduceFuelAmount(int length)
    {
        this.Car.ReduceFuel(length, this.FuelConsumptionPerKm);
    }
}

