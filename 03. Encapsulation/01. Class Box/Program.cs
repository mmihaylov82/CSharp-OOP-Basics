using System;

class Program
{
    static void Main(string[] args)
    {
        double length = double.Parse(Console.ReadLine());
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());

        var box = new Box(length, width, height);

        double surfaceArea = box.CalculateSurfaceArea(length, width, height);
        double lateralSurfaceArea = box.CalculateLateralSurfaceArea(length, width, height);
        double volume = box.CalculateVolume(length, width, height);

        Console.WriteLine($"Surface Area - {surfaceArea:f2}");
        Console.WriteLine($"Lateral Surface Area - {lateralSurfaceArea:f2}");
        Console.WriteLine($"Volume - {volume:f2}");
    }
}

