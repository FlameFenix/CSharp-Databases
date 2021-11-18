using System.Xml.Serialization;

namespace ProductShop.Dtos.Import
{
    [XmlType("Product")]
    public class ImportProductsDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public string Price { get; set; }

        [XmlElement("sellerId")]

        public string SellerId { get; set; }

        [XmlElement("buyerId")]
        [XmlIgnore]
        public string buyerId { get; set; }

        //<name>Care One Hemorrhoidal</name>
        //<price>932.18</price>
        //<sellerId>25</sellerId>
        //<buyerId>24</buyerId>
    }
}
