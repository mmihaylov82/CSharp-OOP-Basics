using System;

class Program
{
    static void Main(string[] args)
    {

        double length = double.Parse(Console.ReadLine());
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());

        try
        {
            var box = new Box(length, width, height);
            
            double surfaceArea = box.CalculateSurfaceArea();
            double lateralSurfaceArea = box.CalculateLateralSurfaceArea();
            double volume = box.CalculateVolume();

            Console.WriteLine($"Surface Area - {surfaceArea:f2}");
            Console.WriteLine($"Lateral Surface Area - {lateralSurfaceArea:f2}");
            Console.WriteLine($"Volume - {volume:f2}");
        }
        catch (ArgumentException ex)
        {

            Console.WriteLine(ex.Message);
        }

    }
}

