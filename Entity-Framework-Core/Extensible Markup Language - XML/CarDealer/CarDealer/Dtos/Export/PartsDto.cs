using System.Xml.Serialization;

namespace CarDealer.Dtos.Export
{
    [XmlType("part")]
    public class PartsDto
    {
        [XmlAttribute("name")]

        public string Name { get; set; }

        [XmlAttribute("price")]

        public string Price { get; set; }
    }
}
