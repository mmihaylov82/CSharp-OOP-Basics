using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>();

        string command;

        while((command = Console.ReadLine()) != "End")
        {
            var tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string name = tokens[0];
            string property = tokens[1];

            if(!people.Any(p => p.Name == name))
            {
                people.Add(new Person(name));
            }

            var currentPerson = people.First(p => p.Name == name);

            switch (property)
            {
                case "company":
                    currentPerson.AssignCompany(tokens[2], tokens[3], decimal.Parse(tokens[4]));
                    break;
                case "pokemon":
                    currentPerson.AddPokemon(tokens[2], tokens[3]);
                    break;
                case "parents":
                    string parentName = tokens[2];
                    currentPerson.AddParent(new Person(parentName, tokens[3]));
                    break;
                case "children":
                    string childName = tokens[2];
                    currentPerson.AddChild(new Person(childName, tokens[3]));
                    break;
                case "car":
                    currentPerson.AssignCar(tokens[2], int.Parse(tokens[3]));
                    break;
                default:
                    throw new Exception();
            }
        }

        command = Console.ReadLine();

        Person result = people.First(p => p.Name == command);
        Console.WriteLine(result);
    }
}
