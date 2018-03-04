using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Program
{
    public static void Main()
    {
        var phones = Console.ReadLine().Split().ToList();
        var sites = Console.ReadLine().Split().ToList();
        var phone = new Smartphone(phones, sites);

        phone.Call();
        phone.Browse();
    }
}

