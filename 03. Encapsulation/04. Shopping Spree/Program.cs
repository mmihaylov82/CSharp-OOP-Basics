using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Person> persons = new List<Person>();
        List<Product> products = new List<Product>();

        var inputPersons = Console.ReadLine().Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var pair in inputPersons)
        {
            var inputArgs = pair.Split("=");
            var name = inputArgs[0];
            var money = decimal.Parse(inputArgs[1]);
            try
            {
                persons.Add(new Person(name, money));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        var inputProduts = Console.ReadLine().Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var pair in inputProduts)
        {
            var inputArgs = pair.Split("=");
            var name = inputArgs[0];
            var cost = decimal.Parse(inputArgs[1]);

            try
            {
                products.Add(new Product(name, cost));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            var commandArgs = command.Split();

            var person = persons.Where(p => p.Name == commandArgs[0]).ToList().FirstOrDefault();
            var product = products.Where(p => p.Name == commandArgs[1]).ToList().FirstOrDefault();
            
            if ((person.Money - product.Cost) < 0)
            {
                Console.WriteLine($"{person.Name} can't afford {product.Name}");
            }
            else
            {
                person.BuyProduct(product);
                Console.WriteLine($"{person.Name} bought {product.Name}");
            }
        }

        foreach (var person in persons)
        {
            if (person.Products.Count == 0)
            {
                Console.WriteLine($"{person.Name} - Nothing bought");
            }
            else
            {
                Console.Write($"{person.Name} - ");
                Console.WriteLine(string.Join(", ", person.Products));
            }
        }
    }
}

