using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.App.Dto.Output
{
    [XmlRoot("users")]
    public class UsersOutDto
    {
        [XmlAttribute("count")]
        public int Count { get; set; }

        [XmlElement("user")]
        public UsersUserOutDto[] Users { get; set; }
    }
}
