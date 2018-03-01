using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int enginesCount = int.Parse(Console.ReadLine());

        List<Engine> engines = new List<Engine>();

        for (int i = 0; i < enginesCount; i++)
        {
            var inputArgs = Console.ReadLine()
                .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string model = inputArgs[0];
            int power = int.Parse(inputArgs[1]);

            if (inputArgs.Length == 2)
            {
                engines.Add(new Engine(model, power));
            }
            else if (inputArgs.Length == 3)
            {
                if (inputArgs[2].All(Char.IsDigit))
                {
                    int displacement = int.Parse(inputArgs[2]);
                    engines.Add(new Engine(model, power, displacement));
                }
                else
                {
                    string efficiency = inputArgs[2];
                    engines.Add(new Engine(model, power, efficiency));
                }
            }
            else if (inputArgs.Length == 4)
            {
                int displacement = int.Parse(inputArgs[2]);
                string efficiency = inputArgs[3];
                engines.Add(new Engine(model, power, displacement, efficiency));
            }
        }

        List<Car> cars = new List<Car>();
        int numberOfCars = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfCars; i++)
        {
            var inputArgs = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string model = inputArgs[0];
            Engine engine = engines.Where(e => e.Model == inputArgs[1]).FirstOrDefault();

            if (inputArgs.Length == 2)
            {
                cars.Add(new Car(model, engine));
            }
            else if (inputArgs.Length == 3)
            {
                if (inputArgs[2].All(Char.IsDigit))
                {
                    int weight = int.Parse(inputArgs[2]);
                    cars.Add(new Car(model, engine, weight));
                }
                else
                {
                    string color = inputArgs[2];
                    cars.Add(new Car(model, engine, color));
                }
            }
            else if (inputArgs.Length == 4)
            {
                int weight = int.Parse(inputArgs[2]);
                string color = inputArgs[3];
                cars.Add(new Car(model, engine, weight, color));
            }
        }

        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }
    }
}
