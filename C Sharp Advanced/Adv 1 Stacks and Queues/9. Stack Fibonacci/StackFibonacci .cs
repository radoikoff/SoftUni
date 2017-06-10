using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.Stack_Fibonacci
{
    public class Program
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var fibonacci = new Stack<double>(new double[] { 0, 1 });

            while (fibonacci.Count != number + 1)
            {
                var secondNumber = fibonacci.Pop();
                var firstNumber = fibonacci.Peek();
                fibonacci.Push(secondNumber);
                fibonacci.Push(firstNumber + secondNumber);
            }

            Console.WriteLine(fibonacci.Peek());

        }
    }
}
