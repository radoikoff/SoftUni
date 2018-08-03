namespace CarDealer.Client.Dto.Output
{
    using System.Xml.Serialization;

    [XmlType("sale")]
    public class SaleOutDto
    {
        public CarOutTwoDto CarData { get; set; }

        [XmlElement("customer-name")]
        public string CustomerName { get; set; }

        [XmlElement("discount")]
        public decimal Discount { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("price-with-discount")]
        public decimal PriceWithDiscount { get; set; }


    }
}
