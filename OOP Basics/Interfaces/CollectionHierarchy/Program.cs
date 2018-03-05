using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Program
{
    public static void Main()
    {
        var addCollection = new AddCollection<string>();
        var addRemoveCollection = new AddRemoveCollection<string>();
        var myList = new MyList<string>();


        var itemsToAdd = Console.ReadLine().Split();
        var resultAdd = new List<int>();
        var resultAddRemove = new List<int>();
        var resultMyList = new List<int>();

        foreach (var item in itemsToAdd)
        {
            resultAdd.Add(addCollection.Add(item));
            resultAddRemove.Add(addRemoveCollection.Add(item));
            resultMyList.Add(myList.Add(item));
        }

        Console.WriteLine(string.Join(" ", resultAdd));
        Console.WriteLine(string.Join(" ", resultAddRemove));
        Console.WriteLine(string.Join(" ", resultMyList));

        var amountToRemove = int.Parse(Console.ReadLine());
        var removeResultAddRemove = new List<string>();
        var removeResultMyList = new List<string>();


        for (int i = 0; i < amountToRemove; i++)
        {
            removeResultAddRemove.Add(addRemoveCollection.Remove());
            removeResultMyList.Add(myList.Remove());
        }

        Console.WriteLine(string.Join(" ", removeResultAddRemove));
        Console.WriteLine(string.Join(" ", removeResultMyList));

    }
}

