namespace CarDealer.Client.Dto
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("customer")]
    public class CustomerDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("birth-date")]
        public DateTime BirthDate { get; set; }

        [StringLength(5, MinimumLength = 4)]
        [XmlElement("is-young-driver")]
        public string IsYoungDriver { get; set; }
    }
}
