using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateModifier
{
    public class DateModifierClass
    {

        public int GetDateDiff(string startDate, string endDate)
        {
            string[] startDateSplit = startDate.Split();

            int year = int.Parse(startDateSplit[0]);
            int month = int.Parse(startDateSplit[1]);
            int day = int.Parse(startDateSplit[2]);
            var dateOne = new DateTime(year, month, day);

            string[] endDateSplit = endDate.Split();
            year = int.Parse(endDateSplit[0]);
            month = int.Parse(endDateSplit[1]);
            day = int.Parse(endDateSplit[2]);

            var dateTwo = new DateTime(year, month, day);

            return Math.Abs((dateTwo - dateOne).Days);
        }

    }
}
