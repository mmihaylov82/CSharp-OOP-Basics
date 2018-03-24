﻿using System;
using System.Collections.Generic;
using System.Text;

public abstract class Tyre
{
    protected Tyre(double hardness)
    {
        this.Hardness = hardness;
        this.Degradation = 100;
    }

    public abstract string Name { get; }

    public double Hardness { get; }

    private double degradation;

    public virtual double Degradation
    {
        get => this.degradation;
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Blown Tyre");
            }
            this.degradation = value;
        }
    }

    public virtual void ReduceDegradation()
    {
        this.Degradation -= this.Hardness;
    }
}

