using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Car
{
    private string model;

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    private decimal fuelAmount;

    public decimal FuelAmount
    {
        get { return fuelAmount; }
        set { fuelAmount = value; }
    }

    private decimal fuelComsumption;

    public decimal FuelConsumption
    {
        get { return fuelComsumption; }
        set { fuelComsumption = value; }
    }

    private int mileage;

    public int Mileage
    {
        get { return mileage; }
        set { mileage = value; }
    }

    public Car(string model, decimal fuelAmount, decimal fuelConsumption)
    {
        this.Model = model;
        this.FuelAmount = fuelAmount;
        this.FuelConsumption = fuelConsumption;
        this.Mileage = 0;
    }

}

