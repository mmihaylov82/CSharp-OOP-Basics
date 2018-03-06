using System;
using System.Collections.Generic;
using System.Text;

public class Dog : Mammal
{
    public const double IncreaseWeightFactor = 0.40;

    public Dog(string name, double weight, string livingRegion) 
        : base(name, weight, livingRegion)
    {
    }

    public override void IncreaseWeight(Food food)
    {
        if (food.GetType().Name == "Meat")
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
        return "Woof!";
    }

    // •	Mice and Dogs – "{AnimalType} [{AnimalName}, {AnimalWeight}, {AnimalLivingRegion}, {FoodEaten}]"
    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}
