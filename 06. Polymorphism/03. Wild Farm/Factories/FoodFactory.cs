using System;
using System.Collections.Generic;
using System.Text;

public static class FoodFactory
{
    public static Food ProduceFood(string[] foodArgs)
    {
        string foodName = foodArgs[0];
        int foodQuantity = int.Parse(foodArgs[1]);
        
        switch (foodName)
        {
            case nameof(Vegetable):
                return new Vegetable(foodQuantity);
            case nameof(Fruit):
                return new Fruit(foodQuantity);
            case nameof(Meat):
                return new Meat(foodQuantity);
            case nameof(Seeds):
                return new Seeds(foodQuantity);
            default:
                throw new ArgumentException("Unknown food type !");
        }
    }
}

