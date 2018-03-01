using System;

class OldestFamilyMember
{
    static void Main(string[] args)
    {
        var numberOfPeople = int.Parse(Console.ReadLine());

        Family myFamily = new Family();

        for (int i = 0; i < numberOfPeople; i++)
        {
            var input = Console.ReadLine().Split();
            var name = input[0];
            var age = int.Parse(input[1]);

            Person person = new Person(name, age);
            myFamily.AddMember(person);

        }
        
        var oldestPerson = myFamily.GetOldestMember();
        Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
    }
}

