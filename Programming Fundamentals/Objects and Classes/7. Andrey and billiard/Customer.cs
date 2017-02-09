using System.Collections.Generic;

namespace _7.Andrey_and_billiard
{
    public class Customer
    {
        public string Name { get; set; }
        public Dictionary<string,int> ShopList { get; set; }
        public decimal Bill { get; set; }
    }
}
