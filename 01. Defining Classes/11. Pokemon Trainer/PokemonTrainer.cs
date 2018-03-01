using System;
using System.Collections.Generic;
using System.Linq;

class PokemonTrainer
{
    static void Main(string[] args)
    {
        var trainers = new List<Trainer>();

        string input;

        while ((input = Console.ReadLine()) != "Tournament")
        {
            var tokens = input.Split();

            string trainerName = tokens[0];
            string pokemonName = tokens[1];
            string pokemontElement = tokens[2];
            int pokemonHealth = int.Parse(tokens[3]);

            if (!trainers.Any(t => t.Name == trainerName))
            {
                trainers.Add(new Trainer(trainerName));
            }

            Pokemon pokemon = new Pokemon(pokemonName, pokemontElement, pokemonHealth);
            Trainer trainer = trainers.First(t => t.Name == trainerName);
            trainer.AddPokemon(pokemon);
        }

        while ((input = Console.ReadLine()) != "End")
        {
            foreach (var trainer in trainers)
            {
                if (trainer.Pokemons.Any(p => p.Element == input))
                {
                    trainer.AddBadge();
                }
                else
                {
                    trainer.ReduceHealth();
                    trainer.RemoveDead();
                }
            }
        }

        foreach (var trainer in trainers.OrderByDescending(t => t.Badges))
        {
            Console.WriteLine(trainer);
        }
    }
}

