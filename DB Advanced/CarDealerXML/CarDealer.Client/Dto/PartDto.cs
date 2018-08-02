namespace CarDealer.Client.Dto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("part")]
    public class PartDto
    {
        [MinLength(3)]
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }

        [XmlAttribute("quantity")]
        public int Quantity { get; set; }
    }
}
