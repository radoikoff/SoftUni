using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.App.Dto.Output
{
    [XmlType("sold-products")]
    public class UserSoldProductsOutDto
    {
        [XmlAttribute("count")]
        public int Count { get; set; }

        [XmlElement("product")]
        public UserSoldProductsProductOutDto[] Products { get; set; }
    }
}
