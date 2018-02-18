using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawData
{
    public class Tyre
    {
        private int age;
        private double pressure;

        public Tyre(int age, double pressure)
        {
            this.Age = age;
            this.Pressure = pressure;
        }

        public double Pressure
        {
            get { return pressure; }
            set { pressure = value; }
        }


        public int Age
        {
            get { return age; }
            set { age = value; }
        }

    }
}
