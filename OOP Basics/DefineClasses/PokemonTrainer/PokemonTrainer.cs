using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTrainer
{
    public class PokemonTrainer
    {
        public static void Main()
        {
            var trainers = new List<Trainer>();
            string input;
            while ((input = Console.ReadLine()) != "Tournament")
            {
                //“<TrainerName> <PokemonName> <PokemonElement> <PokemonHealth>” 
                var tokens = input.Split();
                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);



                if (trainers.Any(t => t.Name == trainerName))
                {
                    var trainer = trainers.FirstOrDefault(t => t.Name == trainerName);
                    trainer.Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
                }
                else
                {
                    var trainer = new Trainer(trainerName);
                    trainer.Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
                    trainers.Add(trainer);
                }
            }

            string element;
            while ((element = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.IsPokemonExists(element))
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        trainer.ReducePokemonsHealth();
                        trainer.RemoveUnhealtyPokemons();
                    }
                }
            }

            foreach (var trainer in trainers.OrderByDescending(t => t.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }

        }
    }
}


