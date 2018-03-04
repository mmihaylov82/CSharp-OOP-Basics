﻿using System;
using System.Collections.Generic;
using System.Text;

public class Private : Soldier, IPrivate
{
    public double Salary { get; set; }

    public Private(string id, string firstName, string lastName, double salary) 
        :base(id, firstName, lastName)
    {
        this.Salary = salary;
    }

    public override string ToString()
    {
        return $"{base.ToString()} Salary: {Salary:F2}";
    }
}
