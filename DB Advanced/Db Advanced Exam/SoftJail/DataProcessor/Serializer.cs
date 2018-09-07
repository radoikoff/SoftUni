namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                                   .Where(p => ids.Contains(p.Id))
                                   .OrderBy(p => p.FullName)
                                   .ThenBy(p => p.Id)
                                   .Select(x => new
                                   {
                                       Id = x.Id,
                                       Name = x.FullName,
                                       CellNumber = x.Cell.CellNumber,
                                       Officers = x.PrisonerOfficers.Select(o => new
                                       {
                                           OfficerName = o.Officer.FullName,
                                           Department = o.Officer.Department.Name
                                       })
                                       .OrderBy(o => o.OfficerName)
                                       .ToArray(),

                                       TotalOfficerSalary = x.PrisonerOfficers.Sum(s => s.Officer.Salary)
                                   })

                                   .ToArray();


            var json = JsonConvert.SerializeObject(prisoners, Newtonsoft.Json.Formatting.Indented);

            return json;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {

            string[] prisonersNamesArray = prisonersNames.Split(',');


            var prisoners = context.Prisoners
                                   .Where(p => prisonersNamesArray.Contains(p.FullName))
                                   .OrderBy(p => p.FullName)
                                   .ThenBy(p => p.Id)
                                   .Select(x => new PrisonerDto
                                   {
                                       Id = x.Id,
                                       Name = x.FullName,
                                       IncarcerationDate = x.IncarcerationDate.ToString("yyyy-MM-dd"),
                                       EncryptedMessages = x.Mails.Select(m => new MessageDto
                                       {
                                           Description = m.EncriptedDescription
                                       })
                                       .ToArray()
                                   })

                                   .ToArray();


            var sb = new StringBuilder();
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var serializer = new XmlSerializer(typeof(PrisonerDto[]), new XmlRootAttribute("Prisoners"));
            serializer.Serialize(new StringWriter(sb), prisoners, xmlNamespaces);

            return sb.ToString();

        }

    }
}