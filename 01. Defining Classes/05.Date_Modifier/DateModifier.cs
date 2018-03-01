using System;
using System.Linq;

public class DateModifier
{
    public int CalculateDate(string first, string second)
    {
        var firstDate = first.Split().Select(int.Parse).ToArray();
        var secondDate = second.Split().Select(int.Parse).ToArray();

        DateTime date1 = new DateTime(firstDate[0], firstDate[1], firstDate[2]);
        DateTime date2 = new DateTime(secondDate[0], secondDate[1], secondDate[2]);

        return Math.Abs((date1 - date2).Days);
    }
}
