using System.Xml.Serialization;

namespace ProductShop.App.Dto.Output
{
    [XmlType("product")]
    public class UserSoldProductsProductOutDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }
    }
}
