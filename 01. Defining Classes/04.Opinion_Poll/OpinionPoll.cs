using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var numberOfPeople = int.Parse(Console.ReadLine());

        List<Person> people = new List<Person>();

        for (int i = 0; i < numberOfPeople; i++)
        {
            var input = Console.ReadLine().Split();
            var name = input[0];
            var age = int.Parse(input[1]);

            Person person = new Person(name, age);
            people.Add(person);
        }

        foreach (var person in people.OrderBy(p => p.Name).Where(p => p.Age > 30))
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}

