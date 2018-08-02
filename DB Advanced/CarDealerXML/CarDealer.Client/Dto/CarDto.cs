namespace CarDealer.Client.Dto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("car")]
    public class CarDto
    {
        [MinLength(3)]
        [XmlElement("make")]
        public string Make { get; set; }

        [MinLength(3)]
        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}
