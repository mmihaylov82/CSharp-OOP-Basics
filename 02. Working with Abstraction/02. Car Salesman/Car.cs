using System;
using System.Collections.Generic;
using System.Text;


class Car
{
    private string model;
    private Engine engine;
    private int? weight;
    private string color;

    public string Model
    {
        get { return model; }
        set { model = value; }
    }
    
    public Engine Engine
    {
        get { return engine; }
        set { engine = value; }
    }
            
    public int? Weight
    {
        get { return weight; }
        set { weight = value; }
    }
       
    public string Color
    {
        get { return color; }
        set { color = value; }
    }

    public Car(string model, Engine engine)
    {
        this.Model = model;
        this.Engine = engine;
    }

    public Car(string model, Engine engine, int? weight)
        :this(model, engine)
    {
        this.Model = model;
        this.Engine = engine;
        this.Weight = weight;
    }

    public Car(string model, Engine engine, string color)
    : this(model, engine)
    {
        this.Model = model;
        this.Engine = engine;
        this.Color = color;
    }

    public Car(string model, Engine engine, int? weight, string color)
        : this(model, engine)
    {
        this.Model = model;
        this.Engine = engine;
        this.Weight = weight;
        this.Color = color;
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendLine($"{Model}:");
        builder.Append(Engine);
        builder.AppendLine($"  Weight: {(Weight == null ? "n/a" : Weight.ToString())}");
        builder.Append($"  Color: {(Color == null ? "n/a" : Color)}");

        return builder.ToString();
    }
}

