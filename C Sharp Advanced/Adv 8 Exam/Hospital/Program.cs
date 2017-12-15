using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class Program
    {

        public class Patient
        {
            public string Name { get; set; }

            public string Department { get; set; }

            public int RoomNumber { get; set; }

            public string DoctorName { get; set; }

            public Patient(string name, string department, string doctor)
            {
                Name = name;
                Department = department;
                //RoomNumber = room;
                DoctorName = doctor;
            }

            public Patient()
            {
            }
        }

        static void Main()
        {
 
            var patients = new List<Patient>();
            var patientsByDepartment = new Dictionary<string, int>();


            var input = Console.ReadLine();
            while (input != "Output")
            {
                var tokens = input.Split().ToArray();
                var department = tokens[0];
                var doctor = tokens[1] + " " + tokens[2];
                var patientName = tokens[3];


                if (!patientsByDepartment.ContainsKey(department))
                {
                    patientsByDepartment.Add(department, 0);
                }


                if (!patients.Any(x => x.Name == patientName) && patientsByDepartment[department] < 60)
                {
                    var patient = new Patient(patientName, department, doctor);

                    int room = (int)Math.Ceiling(patientsByDepartment[department] / 3.0);

                    if (room != 0)
                    {
                        patient.RoomNumber = room;
                    }
                    else
                    {
                        patient.RoomNumber = 1;
                    }
                    patientsByDepartment[department]++;

                    patients.Add(patient);
                }

                input = Console.ReadLine();
            }


            input = Console.ReadLine();
            while (input != "End")
            {
                var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (tokens.Length == 1)
                {
                    //dep
                    foreach (var patient in patients.Where(x => x.Department == tokens[0]))
                    {
                        Console.WriteLine(patient.Name);
                    }
                }
                else
                {
                    //dep/room
                    int room;
                    bool parsed = int.TryParse(tokens[1], out room);
                    if (parsed)
                    {
                        var department = tokens[0];
                        foreach (var patient in patients.Where(x => x.Department == department && x.RoomNumber == room).OrderBy(x => x.Name))
                        {
                            Console.WriteLine(patient.Name);
                        }

                    }
                    else
                    {
                        //doctor
                        var doctorName = tokens[0] + " " + tokens[1];
                        foreach (var patient in patients.Where(x => x.DoctorName == doctorName).OrderBy(x => x.Name))
                        {
                            Console.WriteLine(patient.Name);
                        }
                    }
                }

                input = Console.ReadLine();
            }



        }
    }
}
