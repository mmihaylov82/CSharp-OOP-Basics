using System;
using System.Collections.Generic;
using System.Text;

public class Cat : Feline
{
    public const double IncreaseWeightFactor = 0.30;

    public Cat(string name, double weight, string livingRegion, string breed) 
        : base(name, weight, livingRegion, breed)
    {
    }

    public override void IncreaseWeight(Food food)
    {
        if (food.GetType().Name == "Meat" || food.GetType().Name == "Vegetable")
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
        return "Meow";
    }

    // Felines – "{AnimalType} [{AnimalName}, {Breed}, {AnimalWeight}, {AnimalLivingRegion}, {FoodEaten}]"
    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}
