namespace CarDealer.Client.Dto.Output
{
    using System.Xml.Serialization;

    [XmlType("customer")]
    public class CustomerWithCarsOutDto
    {
        [XmlAttribute("full-name")]
        public string FullName { get; set; }

        [XmlAttribute("bought-cars")]
        public int BoughtCars { get; set; }

        [XmlAttribute("spent-money")]
        public decimal SpentMoney { get; set; }
    }
}
