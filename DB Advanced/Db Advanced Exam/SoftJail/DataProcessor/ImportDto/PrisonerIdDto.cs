using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Prisoner")]
    public class PrisonerIdDto
    {
        [XmlAttribute("id")]
        public int PrisonerId { get; set; }
    }
}
