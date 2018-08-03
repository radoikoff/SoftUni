namespace CarDealer.Client.Dto.Output
{
    using System.Xml.Serialization;

    [XmlType("car")]
    public class CarOutDto
    {
        [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }

        public PartOutDto[] Parts { get; set; }
    }
}
