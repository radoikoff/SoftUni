﻿using System.Xml.Serialization;

namespace ProductShop.App.Dto.Output
{
    [XmlType("category")]
    public class CategoryOutDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("products-count")]
        public int Count { get; set; }

        [XmlElement("average-price")]
        public decimal AveragePrice { get; set; }

        [XmlElement("total-revenue")]
        public decimal TotalRevenue { get; set; }
    }
}
