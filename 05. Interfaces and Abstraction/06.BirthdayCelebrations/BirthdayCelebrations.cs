using System;
using System.Collections.Generic;

namespace _06.BirthdayCelebrations
{
    class BirthdayCelebrations
    {
        static void Main(string[] args)
        {
            List<IBirthdateable> citizensAndPets = new List<IBirthdateable>();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                var commandArgs = command.Split();
                string memberType = commandArgs[0];

                if (memberType == "Citizen")
                {
                    string name = commandArgs[1];
                    int age = int.Parse(commandArgs[2]);
                    string id = commandArgs[3];
                    string birthdate = commandArgs[4];

                    citizensAndPets.Add(new Citizen(name, age, id, birthdate));
                }
                else if (memberType == "Pet")
                {
                    string name = commandArgs[1];
                    string birthdate = commandArgs[2];
                    citizensAndPets.Add(new Pet(name, birthdate));
                }
                else if (memberType == "Robot")
                {
                    continue;
                }
            }

            string yearWanted = Console.ReadLine();

            foreach (var member in citizensAndPets)
            {
                if (member.Birthdate.EndsWith(yearWanted))
                {
                    Console.WriteLine(member.Birthdate);
                }
            }
        }
    }
}
