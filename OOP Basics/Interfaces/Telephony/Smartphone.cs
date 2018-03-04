using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Smartphone : ISmartphone
{
    private List<string> phoneNumbers;
    private List<string> sites;

    public Smartphone(List<string> phoneNumbers, List<string> sites)
    {
        this.phoneNumbers = phoneNumbers;
        this.sites = sites;
    }

    public void Call()
    {
        foreach (var number in phoneNumbers)
        {
            if (IsNumberValid(number))
            {
                Console.WriteLine($"Calling... {number}");
            }
            else
            {
                Console.WriteLine("Invalid number!");
            }
        }
    }

    private bool IsNumberValid(string number)
    {
        if (number.All(c => c >= '0' && c <= '9'))
        {
            return true;
        }
        return false;
    }

    public void Browse()
    {
        foreach (var site in sites)
        {
            if (IsSiteValid(site))
            {
                Console.WriteLine($"Browsing: {site}!");
            }
            else
            {
                Console.WriteLine("Invalid URL!");
            }

        }
    }

    private bool IsSiteValid(string site)
    {
        if (site.Any(c => c >= '0' && c <= '9'))
        {
            return false;
        }
        return true;
    }
}

