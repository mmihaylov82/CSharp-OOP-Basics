﻿using System;
using System.Collections.Generic;
using System.Text;

public class Mouse : Mammal
{
    public const double IncreaseWeightFactor = 0.10;

    public Mouse(string name, double weight, string livingRegion) 
        : base(name, weight, livingRegion)
    {
    }

    public override void IncreaseWeight(Food food)
    {
        if (food.GetType().Name == "Vegetable" || food.GetType().Name == "Fruit")
        {
            this.Weight += food.FoodQuantity * IncreaseWeightFactor; 
            this.FoodEaten += food.FoodQuantity;
        }
        else
        {
            throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
    }

    public override string ProduceSound()
    {
        return "Squeak";
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}
