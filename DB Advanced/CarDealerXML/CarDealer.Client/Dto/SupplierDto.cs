namespace CarDealer.Client.Dto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("supplier")]
    public class SupplierDto
    {
        [MinLength(3)]
        [XmlAttribute("name")]
        public string Name { get; set; }

        [StringLength(5, MinimumLength = 4)]
        [XmlAttribute("is-importer")]
        public string IsImporter { get; set; }
    }
}
