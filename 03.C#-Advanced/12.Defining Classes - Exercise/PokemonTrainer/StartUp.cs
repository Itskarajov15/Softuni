using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var trainers = new List<Trainer>();
            var pokemons = new List<Pokemon>();

            var command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "Tournament")
            {
                string trainerName = command[0];
                string pokemonName = command[1];
                string pokemonElement = command[2];
                int pokemonHealth = int.Parse(command[3]);

                if (!trainers.Any(x => x.Name == trainerName))
                {
                    trainers.Add(new Trainer(trainerName));
                }

                var currTrainer = trainers.Find(x => x.Name == trainerName);

                currTrainer.Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));

                command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            string typeOfPokemon = Console.ReadLine();

            while (typeOfPokemon != "End")
            {
                if (typeOfPokemon == "Fire")
                {
                    DoActionsWithPokemons(typeOfPokemon, trainers);
                }
                else if (typeOfPokemon == "Water")
                {
                    DoActionsWithPokemons(typeOfPokemon, trainers);
                }
                else if (typeOfPokemon == "Electricity")
                {
                    DoActionsWithPokemons(typeOfPokemon, trainers);
                }

                typeOfPokemon = Console.ReadLine();
            }

            trainers = trainers.OrderByDescending(x => x.NumberOfBadges)
                .ToList();

            foreach (var trainer in trainers)
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }
        }

        static void DoActionsWithPokemons(string typeOfPokemon, List<Trainer> trainers)
        {
            foreach (var trainer in trainers)
            {
                if (!trainer.Pokemons.Any(x => x.Element == typeOfPokemon))
                {
                    for (int i = 0; i < trainer.Pokemons.Count; i++)
                    {
                        trainer.Pokemons[i].Health -= 10;

                        if (trainer.Pokemons[i].Health <= 0)
                        {
                            trainer.Pokemons.Remove(trainer.Pokemons[i]);
                            i--;
                        }
                    }
                }
                else
                {
                    trainer.NumberOfBadges++;
                }
            }
        }
    }
}
