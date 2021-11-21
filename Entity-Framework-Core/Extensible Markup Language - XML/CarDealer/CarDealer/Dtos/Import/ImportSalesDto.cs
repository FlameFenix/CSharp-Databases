﻿using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [XmlType("Sale")]
    public class ImportSalesDto
    {
        [XmlElement("carId")]
        public string CarId { get; set; }

        [XmlElement("customerId")]
        public string CustomerId { get; set; }

        [XmlElement("discount")]
        public string Discount { get; set; }
    }
}
