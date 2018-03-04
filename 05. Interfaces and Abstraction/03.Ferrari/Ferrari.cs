using System;
using System.Collections.Generic;
using System.Text;

public class Ferrari : ICar
{
    public string Model { get; set; }

    public string Driver { get; set; }

    public Ferrari(string driver)
    {
        this.Driver = driver;
        this.Model = "488-Spider";
    }

    public string UseBrakes()
    {
        return "Brakes!";
    }

    public string PushGasPedal()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        return $"{this.Model}/{this.UseBrakes()}/{this.PushGasPedal()}/{this.Driver}";
    }
}

