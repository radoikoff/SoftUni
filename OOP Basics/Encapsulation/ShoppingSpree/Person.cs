using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private int money;
        private List<Product> bag;

        public Person(string name, int money)
        {
            this.Name = name;
            this.Money = money;
            this.bag = new List<Product>();
        }

        //public List<Product> Bag
        //{
        //    get { return bag; }
        //    set { bag = value; }
        //}


        public int Money
        {
            get { return money; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Money cannot be negative");
                }
                money = value;
            }
        }


        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException("Name cannot be empty");
                }
                name = value;
            }
        }

        public string AddProduct(Product product)
        {
            if (Money - product.Cost >= 0)
            {
                bag.Add(product);
                Money -= product.Cost;
                return $"{this.Name} bought {product.Name}";
            }
            else
            {
                return $"{this.Name} can't afford {product.Name}";
            }

        }

        public override string ToString()
        {
            if (bag.Count != 0)
            {
                return $"{this.Name} - {string.Join(", ", bag.Select(p => p.Name))}";
            }
            else
            {
                return $"{this.Name} - Nothing bought";
            }

        }

    }
}
