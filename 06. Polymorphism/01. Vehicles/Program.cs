using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IVehicle> vehicles = new List<IVehicle>();

            var input = Console.ReadLine().Split();
            double fuelQuantity = double.Parse(input[1]);
            double fuelConsumption = double.Parse(input[2]);
            Car car = new Car(fuelQuantity, fuelConsumption);
            vehicles.Add(car);

            input = Console.ReadLine().Split();
            fuelQuantity = double.Parse(input[1]);
            fuelConsumption = double.Parse(input[2]);
            Truck truck = new Truck(fuelQuantity, fuelConsumption);
            vehicles.Add(truck);

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                var commandArgs = Console.ReadLine().Split();

                string command = commandArgs[0];
                string vehicleType = commandArgs[1];
                IVehicle currentVehicle = vehicles.First(v => v.GetType().Name == vehicleType);

                if (command == "Drive")
                {
                    var distance = double.Parse(commandArgs[2]);
                    currentVehicle.Drive(distance);
                }
                else if (command == "Refuel")
                {
                    var quantity = double.Parse(commandArgs[2]);
                    currentVehicle.Refuel(quantity);
                }
            }

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }
    }
}
