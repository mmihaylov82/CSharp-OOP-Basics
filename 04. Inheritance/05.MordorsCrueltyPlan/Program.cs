using System;
using MordorsCrueltyPlan.Models.FoodModels;
using System.Collections.Generic;
using MordorsCrueltyPlan.Models;

namespace MordorsCrueltyPlan
{
    class Program
    {
        static void Main(string[] args)
        {
            var foodNames = Console.ReadLine().ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            List<Food> foods = new List<Food>();

            var ff = new FoodFactory();

            foreach (var name in foodNames)
            {
                foods.Add(ff.CreateFood(name));
            }

            Gandalf gandalf = new Gandalf(foods);

            Console.WriteLine(gandalf.ToString());
            
        }
    }
}
