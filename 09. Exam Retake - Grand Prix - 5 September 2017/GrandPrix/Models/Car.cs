using System;
using System.Collections.Generic;
using System.Text;

public class Car
{
    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.FuelAmount = fuelAmount;
        this.Hp = hp;
        this.Tyre = tyre;
    }

    private const int TANK_CAPACITY = 160;

    public int Hp { get; }

    private double fuelAmount;

    public double FuelAmount
    {
        get { return this.fuelAmount; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Out of fuel");
            }
            if (value > TANK_CAPACITY)
            {
                this.fuelAmount = TANK_CAPACITY;
            }
            else
            {
                fuelAmount = value;
            }
        }
    }

    public Tyre Tyre { get; private set; }

    public void ReduceFuel(int length, double fuelConsumption)
    {
        this.FuelAmount = this.FuelAmount - (length * fuelConsumption);
    }

    public void Refuel(double fuel)
    {
        this.FuelAmount += fuel;
    }

    public void ChangeTyre(Tyre newTyre)
    {
        this.Tyre = newTyre;
    }
}

