using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google
{
    public class Person
    {
        public Person(string name)
        {
            Name = name;
            Parents = new List<Parent>();
            Children = new List<Child>();
            Pokemons = new List<Pokemon>();
        }

        public string Name { get; set; }
        public Car Car { get; set; }
        public Company Company { get; set; }
        public List<Parent> Parents { get; set; }
        public List<Child> Children { get; set; }
        public List<Pokemon> Pokemons { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(Name);
            sb.AppendLine("Company:");
            if (Company != null)
            {
                sb.AppendLine(Company.ToString());
            }

            sb.AppendLine("Car:");
            if (Car != null)
            {
                sb.AppendLine(Car.ToString());
            }

            sb.AppendLine("Pokemon:");
            foreach (var pokemon in Pokemons)
            {
                sb.AppendLine(pokemon.ToString());
            }

            sb.AppendLine("Parents:");
            foreach (var parent in Parents)
            {
                sb.AppendLine(parent.ToString());
            }

            sb.AppendLine("Children:");
            foreach (var child in Children)
            {
                sb.AppendLine(child.ToString());
            }

            return sb.ToString();
        }
    }
}
