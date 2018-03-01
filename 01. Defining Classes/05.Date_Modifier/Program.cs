using System;

class Program
{
    static void Main(string[] args)
    {
        string dateOne = Console.ReadLine();
        string dateTwo = Console.ReadLine();
        DateModifier dateModifier = new DateModifier();

        Console.WriteLine(dateModifier.CalculateDate(dateOne, dateTwo));
    }
}

