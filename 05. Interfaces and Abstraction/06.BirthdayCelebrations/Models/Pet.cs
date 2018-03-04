using System;
using System.Collections.Generic;
using System.Text;

public class Pet : IBirthdateable
{
    public string Name { get; private set; }
    public string Birthdate { get; private set; }

    public Pet(string name, string birthdate)
    {
        this.Name = name;
        this.Birthdate = birthdate;
    }
}

