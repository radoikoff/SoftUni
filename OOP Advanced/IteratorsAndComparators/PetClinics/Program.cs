using System;
using System.Collections.Generic;
using System.Linq;

namespace PetClinics
{
    public class Program
    {
        public static void Main()
        {
            var pets = new List<Pet>();
            var clinics = new List<PetClinic>();

            int commandCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandCount; i++)
            {
                string[] cmdargs = Console.ReadLine().Split();
                string command = cmdargs[0];


                switch (command)
                {
                    case "Create":
                        try
                        {
                            var creationkind = cmdargs[1];
                            if (creationkind == "Pet")
                            {
                                string name = cmdargs[2];
                                int age = int.Parse(cmdargs[3]);
                                string kind = cmdargs[4];

                                pets.Add(new Pet(name, age, kind));
                            }
                            else
                            {
                                string name = cmdargs[2];
                                int roomCount = int.Parse(cmdargs[3]);
                                clinics.Add(new PetClinic(name, roomCount));
                            }
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "Add":
                        string petName = cmdargs[1];
                        string clinicName = cmdargs[2];
                        Pet petToAdd = pets.FirstOrDefault(p => p.Name == petName);
                        PetClinic clinicToAdd = clinics.FirstOrDefault(p => p.Name == clinicName);
                        Console.WriteLine(clinicToAdd.Add(petToAdd));
                        break;

                    case "Release":
                        string clinicNameToRelease = cmdargs[1];
                        PetClinic clinicToRelease = clinics.FirstOrDefault(p => p.Name == clinicNameToRelease);
                        Console.WriteLine(clinicToRelease.Release());
                        break;
                    case "HasEmptyRooms":
                        string clinicNameToCheck = cmdargs[1];
                        PetClinic clinicToCheck = clinics.FirstOrDefault(p => p.Name == clinicNameToCheck);
                        Console.WriteLine(clinicToCheck.HasEmptyRooms);
                        break;

                    case "Print":
                        string clinicNameToPrint = cmdargs[1];
                        PetClinic clinicToPrint = clinics.FirstOrDefault(p => p.Name == clinicNameToPrint);
                        if (cmdargs.Length == 3)
                        {
                            int roomNumber = int.Parse(cmdargs[2]);
                            Console.WriteLine(clinicToPrint.Print(roomNumber));
                        }
                        else
                        {
                            Console.WriteLine(clinicToPrint.PrintAll());
                        }
                        break;

                }



            }
        }
    }
}
