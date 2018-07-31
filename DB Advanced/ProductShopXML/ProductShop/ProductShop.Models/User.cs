namespace ProductShop.Models
{
    using System.Collections.Generic;

    public class User
    {
        public User()
        {
            this.ProdcutsSold = new List<Product>();
            this.ProdcutsBought = new List<Product>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? Age { get; set; }

        public ICollection<Product> ProdcutsSold { get; set; }

        public ICollection<Product> ProdcutsBought { get; set; }
    }
}
