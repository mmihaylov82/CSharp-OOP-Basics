using System;
using System.Collections.Generic;
using System.Text;

public class Engineer : SpecialisedSoldier, IEngineer
{
    public List<Repair> Repairs { get; private set; }

    public Engineer(string id, string firstName, string lastName, double salary, string corps)
        :base(id, firstName, lastName, salary, corps)
    {
        this.Repairs = new List<Repair>();
    }

    public void AddRepair(Repair repair)
    {
        this.Repairs.Add(repair);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(base.ToString())
            .AppendLine($"Repairs:");

        foreach (var repair in Repairs)
        {
            sb.AppendLine(repair.ToString());
        }

        return sb.ToString().TrimEnd();
    }
}

