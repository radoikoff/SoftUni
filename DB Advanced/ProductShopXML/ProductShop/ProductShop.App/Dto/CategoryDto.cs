﻿namespace ProductShop.App.Dto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("category")]
    public class CategoryDto
    {
        [StringLength(15, MinimumLength = 3)]
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
