using System;
using System.Collections.Generic;
using System.Text;

public class Box
{
    private double Length { get; set; }

    private double Width { get; set; }

    private double Height { get; set; }

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Height = height;
        this.Width = width;
    }

    public double CalculateSurfaceArea(double length, double width, double height)
    {
        return (2 * length * width + 2 * length * height + 2 * width * height);
    }

    public double CalculateLateralSurfaceArea(double length, double width, double height)
    {
        return (2 * length * height + 2 * width * height);
    }

    public double CalculateVolume(double length, double width, double height)
    {
        return (length * width * height);
    }
}

