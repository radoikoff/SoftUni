using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name)
        {
            Name = name;
            NumberOfBadges = 0;
            Pokemons = new List<Pokemon>();
        }

        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> Pokemons { get; set; }

        public bool IsPokemonExists(string element)
        {
            return Pokemons.Any(p => p.Element.Equals(element));
        }

        public void ReducePokemonsHealth()
        {
            Pokemons.ForEach(p => p.Health -= 10);
        }

        public void RemoveUnhealtyPokemons()
        {
            Pokemons.RemoveAll(p => p.Health <= 0);
        }
    }
}
