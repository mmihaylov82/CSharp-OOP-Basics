using System;
using System.Collections.Generic;

namespace _03.WildFarm
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] animalArgs = command.Split();
                string[] foodArgs = Console.ReadLine().Split();
                                
                try
                {
                    Animal animal = AnimalFactory.ProduceAnimal(animalArgs);
                    animals.Add(animal);

                    Food food = FoodFactory.ProduceFood(foodArgs);

                    Console.WriteLine(animal.ProduceSound());
                    animal.IncreaseWeight(food);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
