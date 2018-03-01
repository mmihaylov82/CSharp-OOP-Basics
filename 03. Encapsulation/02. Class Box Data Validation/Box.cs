using System;
using System.Collections.Generic;
using System.Text;

public class Box
{
    private double length;
    private double width;
    private double height;

    public double Length
    {
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Length cannot be zero or negative.");
            }
            this.length = value;
            
        }
    }

    public double Width
    {
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Width cannot be zero or negative.");
            }
            this.width = value;
        }
    }

    public double Height
    {
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Height cannot be zero or negative.");
            }
            this.height = value;
        }
    }

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Height = height;
        this.Width = width;
    }

    public double CalculateSurfaceArea()
    {
        return (2 * length * width + 2 * length * height + 2 * width * height);
    }

    public double CalculateLateralSurfaceArea()
    {
        return (2 * length * height + 2 * width * height);
    }

    public double CalculateVolume()
    {
        return (length * width * height);
    }
}

