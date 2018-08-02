using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.App.Dto.Output
{
    [XmlType("user")]
    public class UsersUserOutDto
    {
        [XmlAttribute("first-name")]
        public string FirstName { get; set; }

        [XmlAttribute("last-name")]
        public string LastName { get; set; }

        [XmlAttribute("age")]
        public string Age { get; set; }

        [XmlElement("sold-products")]
        public UserSoldProductsOutDto SoldProducts { get; set; }
    }
}
