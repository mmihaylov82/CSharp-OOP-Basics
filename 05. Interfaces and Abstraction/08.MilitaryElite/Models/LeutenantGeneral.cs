using System.Collections.Generic;
using System.Text;

public class LeutenantGeneral : Private, ILeutenantGeneral
{
    public List<Private> Privates { get; private set; }

    public LeutenantGeneral(string id, string firstName, string lastName, double salary)
        :base(id, firstName, lastName, salary)
    {
        this.Privates = new List<Private>();
    }

    public void AddPrivate(Private privat)
    {
        this.Privates.Add(privat);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine(base.ToString())
            .AppendLine($"Privates:");

        foreach (var privat in Privates)
        {
            sb.AppendLine(privat.ToString());
        }

        return sb.ToString().TrimEnd();
    }
}

