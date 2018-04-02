using System;
using System.Linq;

namespace ListyIterator
{
    public class Program
    {
        public static void Main()
        {

            var command = Console.ReadLine();
            var data = command.Split().Skip(1);

            var listyIterator = new ListyIterator<string>(data);

            while (!(command = Console.ReadLine()).Equals("END"))
            {
                switch (command)
                {
                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;
                    case "Print":
                        try
                        {
                            listyIterator.Print();
                        }
                        catch (InvalidOperationException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;
                    case "PrintAll":
                        listyIterator.PrintAll();
                        break;

                }
            }
        }

    }
}
