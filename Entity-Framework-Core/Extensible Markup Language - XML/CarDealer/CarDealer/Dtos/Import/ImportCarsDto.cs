using CarDealer.Models;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [XmlType("Car")]
    public class ImportCarsDto
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("TraveledDistance")]
        public string TraveledDistance { get; set; }

        [XmlArray("parts")]
        public ImportPartCarDto[] Parts { get; set; }
    }
}
