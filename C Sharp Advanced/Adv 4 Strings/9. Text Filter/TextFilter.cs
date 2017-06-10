using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.Text_Filter
{
    public class TextFilter
    {
        public static void Main()
        {
            var bannedList = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            string text = Console.ReadLine();

            for (int i = 0; i < bannedList.Length; i++)
            {
                text = text.Replace(bannedList[i], new string('*', bannedList[i].Length));
            }

            Console.WriteLine(text);
        }

    }
}
