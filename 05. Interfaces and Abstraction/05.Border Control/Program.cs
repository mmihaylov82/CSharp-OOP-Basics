using System;
using System.Collections.Generic;

namespace _05.Border_Control
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IIdentable> townPopulation = new List<IIdentable>();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                var commandArgs = command.Split();
                if (commandArgs.Length == 3)
                {
                    string name = commandArgs[0];
                    int age = int.Parse(commandArgs[1]);
                    string id = commandArgs[2];
                    Citizen citizen = new Citizen(name, age, id);
                    townPopulation.Add(citizen);
                }
                else if (commandArgs.Length == 2)
                {
                    string model = commandArgs[0];
                    string id = commandArgs[1];
                    Robot robot = new Robot(model, id);
                    townPopulation.Add(robot);
                }
            }

            string fakeIdString = Console.ReadLine();

            foreach (var resident in townPopulation)
            {
                if (resident.Id.EndsWith(fakeIdString))
                {
                    Console.WriteLine(resident.Id);
                }
            }
        }
    }
}
