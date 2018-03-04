using System;
using System.Collections.Generic;
using System.Text;

public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
{
    private Corps corps;
    
    public string Corps
    {
        get
        {
            return this.corps.ToString();
        }
        private set
        {
            Corps corps;

            if (!Enum.TryParse<Corps>(value, out corps))
            {
                throw new ArgumentException();
            }

            this.corps = corps;
        }
    }

    public SpecialisedSoldier(string id, string firstName, string lastName, double salary, string corps)
        :base(id, firstName, lastName, salary)
    {
        this.Corps = corps;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(base.ToString())
            .AppendLine($"Corps: {Corps}");

        return sb.ToString().TrimEnd();
    }
}

