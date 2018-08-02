using System.Xml.Serialization;

namespace ProductShop.App.Dto.Output
{
    [XmlType("user")]
    public class UserOutDto
    {
        [XmlAttribute("first-name")]
        public string FirstName { get; set; }

        [XmlAttribute("last-name")]
        public string LastName { get; set; }

        [XmlArray("sold-products")]
        public SoldProductsOutDto[] SoldProducts { get; set; }
    }
}
