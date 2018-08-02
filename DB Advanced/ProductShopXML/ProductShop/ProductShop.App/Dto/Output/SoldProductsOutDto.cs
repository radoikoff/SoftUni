using System.Xml.Serialization;

namespace ProductShop.App.Dto.Output
{
    [XmlType("product")]
    public class SoldProductsOutDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}
