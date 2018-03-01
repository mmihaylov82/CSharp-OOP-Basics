using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<Car> cars = new List<Car>();

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split().ToArray();
            var carModel = input[0];
            var fuelAmount = decimal.Parse(input[1]);
            var fuelConsumption = decimal.Parse(input[2]);

            Car car = new Car(carModel, fuelAmount, fuelConsumption);
            cars.Add(car);
        }

        string carMoves;
        while ((carMoves = Console.ReadLine()) != "End")
        {
            var inputArgs = carMoves.Split().ToArray();

            if (!cars.Any(c => c.Model == inputArgs[1]))
            {
                continue;
            }

            var distanceToTravel = int.Parse(inputArgs[2]);
            var car = cars.FirstOrDefault(c => c.Model == inputArgs[1]);

            if (car.FuelAmount < (car.FuelConsumption * distanceToTravel))
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                car.FuelAmount -= car.FuelConsumption * distanceToTravel;
                car.Mileage += distanceToTravel;
            }
        }

        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.Mileage}");
        }
    }
}

