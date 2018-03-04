using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.FoodShortage
{
    class FoodShortage
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());

            List<IBuyer> community = new List<IBuyer>();
            
            for (int i = 0; i < numberOfPeople; i++)
            {
                var input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);

                if (input.Length == 4)
                {
                    string id = input[2];
                    string birthdate = input[3];

                    community.Add(new Citizen(name, age, id, birthdate));
                }
                else if (input.Length == 3)
                {
                    string group = input[2];

                    community.Add(new Rebel(name, age, group));
                }
            }

            string personName;

            while ((personName = Console.ReadLine()) != "End")
            {
                foreach (var member in community.Where(m => m.Name == personName))
                {
                    member.BuyFood();
                }
            }

            var foodTotal = community.Sum(p => p.Food);
            Console.WriteLine(foodTotal);
        }
    }
}
