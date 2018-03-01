using System;
using System.Collections.Generic;
using System.Text;

public class Product
{
    private string name;
    private decimal cost;


    public decimal Cost
    {
        get
        {
            return this.cost;
        }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }

            this.cost = value;
        }
    }

    public string Name
    {
        get { return name; }
        private set
        {
            if (String.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            name = value;
        }
    }

    public Product(string name, decimal cost)
    {
        this.Name = name;
        this.Cost = cost;
    }

    public override string ToString()
    {
        return $"{this.Name}";
    }
}

