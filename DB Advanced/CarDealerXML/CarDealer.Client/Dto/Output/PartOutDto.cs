namespace CarDealer.Client.Dto.Output
{
    using System.Xml.Serialization;

    [XmlType("part")]
    public class PartOutDto
    {

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }
    }
}
