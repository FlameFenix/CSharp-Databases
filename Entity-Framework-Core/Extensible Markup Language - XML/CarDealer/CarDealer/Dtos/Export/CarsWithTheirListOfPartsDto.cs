using System.Xml.Serialization;

namespace CarDealer.Dtos.Export
{
    [XmlType("car")]
    public class CarsWithTheirListOfPartsDto
    {
        [XmlAttribute("make")]

        public string Make { get; set; }

        [XmlAttribute("model")]

        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]

        public string TravelledDistance { get; set; }

        [XmlArray("parts")]

        public PartsDto[] Parts { get; set; }
    }
}
