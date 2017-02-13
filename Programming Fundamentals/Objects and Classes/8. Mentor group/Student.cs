using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.Mentor_groups
{
    public class Student
    {
        public string Name { get; set; }
        public List<DateTime> AttendanceDates { get; set; }
        public List<string> Comments { get; set; }
    }
}
