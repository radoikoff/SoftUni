namespace SoftJail.DataProcessor
{
    using AutoMapper;
    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    using DA = System.ComponentModel.DataAnnotations;

    public class Deserializer
    {

        private const string ERR_MSG = "Invalid Data";

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {

            var deserializedDepartments = JsonConvert.DeserializeObject<DepartmentDto[]>(jsonString);
            var sb = new StringBuilder();

            var validDepartments = new List<Department>();


            foreach (var departmentDto in deserializedDepartments)
            {
                bool allValid = true;

                if (!IsValid(departmentDto))
                {
                    sb.AppendLine(ERR_MSG);
                    continue;
                }

                foreach (var cellDto in departmentDto.Cells)
                {
                    if (!IsValid(cellDto))
                    {
                        sb.AppendLine(ERR_MSG);
                        allValid = false;
                        break;
                    }
                }

                if (!allValid)
                {
                    continue;
                }


                var department = Mapper.Map<Department>(departmentDto);

                validDepartments.Add(department);

                sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
            }

            context.Departments.AddRange(validDepartments);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var deserializedPrisoners = JsonConvert.DeserializeObject<PrisonerDto[]>(jsonString);
            var sb = new StringBuilder();

            var validPrisoners = new List<Prisoner>();

            foreach (var prisonerDto in deserializedPrisoners)
            {
                bool allValid = true;

                if (!IsValid(prisonerDto))
                {
                    sb.AppendLine(ERR_MSG);
                    continue;
                }

                foreach (var mailDto in prisonerDto.Mails)
                {
                    if (!IsValid(mailDto))
                    {
                        sb.AppendLine(ERR_MSG);
                        allValid = false;
                        break;
                    }
                }

                if (!allValid)
                {
                    continue;
                }


                var prisoner = Mapper.Map<Prisoner>(prisonerDto);

                validPrisoners.Add(prisoner);

                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }

            context.Prisoners.AddRange(validPrisoners);
            context.SaveChanges();

            return sb.ToString();

        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(OfficerDto[]), new XmlRootAttribute("Officers"));
            var deserializedOficers = (OfficerDto[])serializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var officers = new List<Officer>();

            foreach (var officerDto in deserializedOficers)
            {
                bool allValid = true;

                if (!IsValid(officerDto))
                {
                    sb.AppendLine(ERR_MSG);
                    continue;
                }

                foreach (var prisonerDto in officerDto.Prisoners)
                {
                    if (!IsValid(prisonerDto))
                    {
                        sb.AppendLine(ERR_MSG);
                        allValid = false;
                        break;
                    }
                }

                if (!allValid)
                {
                    continue;
                }



                var officer = Mapper.Map<Officer>(officerDto);
                


                officers.Add(officer);

                sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");
            }

            context.Officers.AddRange(officers);
            context.SaveChanges();

            return sb.ToString();
        }


        private static bool IsValid(object obj)
        {
            var validationContext = new DA.ValidationContext(obj);
            var results = new List<DA.ValidationResult>();
            return DA.Validator.TryValidateObject(obj, validationContext, results, true);
        }
    }
}