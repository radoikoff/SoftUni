using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateModifier
{
    class DateModifier
    {
        public static void Main()
        {
            var startDateAsString = Console.ReadLine();
            var endDateAsString = Console.ReadLine();
            var dateModifier = new DateModifierClass();
            Console.WriteLine(dateModifier.GetDateDiff(startDateAsString, endDateAsString));
        }
    }
}
